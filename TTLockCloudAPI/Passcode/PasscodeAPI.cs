using System;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public class PasscodeAPI : TTLockCloudAPI, IPasscodeAPI
    {
        private Passcode _passcode;

        public PasscodeAPI(Uri serverUri = null)
            : base("v3/keyboardPwd/", serverUri)
        { }

        public Passcode PasscodeToOperate
        {
            get => _passcode ?? throw Error.InvalidOperation("Pass code to operate wasn't set");
            set => _passcode = value.IsNotNull(nameof(value));
        }

        public async Task<CustomPasscode> AddCustomPasscode(int lockId, NewCustomPasscodeData data, LockModificationWay modificationWay)
        {
            data.IsNotNull(nameof(data));
            modificationWay.IsExist();

            var dto = await PostRequest<CustomPasscodeDto>("add",
                CreateDictionary(
                    "lockId", lockId.ToString(),
                    "keyboardPwd", data.Passcode,
                    "keyboardPwdName", data.PasscodeName,
                    "startDate", data.BeginningTime.GetUnixTimeInMilliseconds().ToString(),
                    "endDate", data.ExpirationTime.GetUnixTimeInMilliseconds().ToString(),
                    "addType", modificationWay.ToString("d")
                )
            ).ConfigureAwait(false);

            return new CustomPasscode(dto.keyboardPwdId, lockId);
        }

        public async Task<GeneratedPasscode> GeneratePasscode(int lockId, NewGeneratedPasscodeData data)
        {
            data.IsNotNull(nameof(data));

            var dto = await PostRequest<GeneratedPasscodeDto>("get",
                CreateDictionary(
                    "lockId", lockId.ToString(),
                    "keyboardPwdVersion", data.PasscodeVersion.ToString(),
                    "keyboardPwdType", data.PasscodeType.ToString("d"),
                    "startDate", data.BeginningTime.GetUnixTimeInMilliseconds().ToString(),
                    "endDate", data.ExpirationTime.GetUnixTimeInMilliseconds().ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(() => new GeneratedPasscode(dto.keyboardPwdId, lockId, dto.keyboardPwd));
        }

        public Task DeletePasscode(LockModificationWay modificationWay)
        {
            modificationWay.IsExist();

            return PostRequest("delete",
                CreateDictionary(
                    "lockId", PasscodeToOperate.LockId.ToString(),
                    "keyboardPwdId", PasscodeToOperate.Id.ToString(),
                    "deleteType", modificationWay.ToString("d")
                )
            );
        }

        public Task ChangePasscode(string newValue, DateTime? newBeginningTime, DateTime? newExpirationTime, LockModificationWay modificationWay)
        {
            modificationWay.IsExist();

            var requestData = CreateDictionary(
                "lockId", PasscodeToOperate.LockId.ToString(),
                "keyboardPwdId", PasscodeToOperate.Id.ToString(),
                "changeType", modificationWay.ToString("d")
            );
            if (!string.IsNullOrWhiteSpace(newValue))
                requestData.Add("newKeyboardPwd", newValue);
            if (newBeginningTime != null)
                requestData.Add("startDate", newBeginningTime.Value.GetUnixTimeInMilliseconds().ToString());
            if (newExpirationTime != null)
                requestData.Add("endDate", newExpirationTime.Value.GetUnixTimeInMilliseconds().ToString());

            return PostRequest("change", requestData);
        }
    }
}
