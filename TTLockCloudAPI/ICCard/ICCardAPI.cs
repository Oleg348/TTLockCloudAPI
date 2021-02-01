using System;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public class ICCardAPI : TTLockCloudAPI, IICCardAPI
    {
        private ICCard _icCard;

        public ICCardAPI(Uri serverUri = null)
            : base("v3/identityCard/", serverUri)
        { }

        public ICCard ICCardToOperate
        {
            get => _icCard ?? throw Error.InvalidOperation("IC card wasn't set");
            set => _icCard = value.IsNotNull(nameof(ICCardToOperate));
        }

        public async Task<PageResult<UserICCard>> GetAllICCards(int lockId, int page = 1, int pageSize = 20)
        {
            var dto = await PostRequest<PageResultDto<ICCardDto>>("list",
                CreateDictionary(
                    "lockId", lockId.ToString(),
                    "pageNo", page.ToString(),
                    "pageSize", pageSize.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(
                () => dto.ToPageResult(
                    c => new UserICCard(
                        c.cardId,
                        c.lockId,
                        c.cardNumber,
                        c.cardName,
                        c.startDate.GetDateTimeFromUnixMilliseconds(),
                        c.endDate.GetDateTimeFromUnixMilliseconds(),
                        c.createDate.GetDateTimeFromUnixMilliseconds(),
                        (ICCardStatus)c.status,
                        c.senderUsername
                    )
                )
            );
        }

        public async Task<ICCard> AddICCard(int lockId, NewICCardData data, LockModificationWay modificationWay)
        {
            data.IsNotNull(nameof(data));
            modificationWay.IsExist();

            var dto = await PostRequest<AddCardResultDto>("add",
                CreateDictionary(
                    "lockId", lockId.ToString(),
                    "cardNumber", data.CardNumber,
                    "cardName", data.CardName,
                    "startDate", data.BeginningTime.GetUnixTimeInMilliseconds().ToString(),
                    "endDate", data.ExpirationTime.GetUnixTimeInMilliseconds().ToString(),
                    "addType", modificationWay.ToString("d")
                )
            ).ConfigureAwait(false);

            return new ICCard(dto.cardId, lockId);
        }

        public Task DeleteICCard(LockModificationWay modificationWay)
        {
            modificationWay.IsExist();

            return PostRequest("delete",
                CreateDictionary(
                    "lockId", ICCardToOperate.LockId.ToString(),
                    "cardId", ICCardToOperate.Id.ToString(),
                    "deleteType", modificationWay.ToString("d")
                )
            );
        }

        public Task ClearAllLockICCards(int lockId)
        {
            return PostRequest("clear",
                CreateDictionary(
                    "lockId", lockId.ToString()
                )
            );
        }

        public Task ChangeICCardValidityPeriod(DateTime? beginningTime, DateTime? expirationTime, LockModificationWay modificationWay)
        {
            modificationWay.IsExist();

            var requestData = CreateDictionary(
                "lockId", ICCardToOperate.LockId.ToString(),
                "cardId", ICCardToOperate.Id.ToString(),
                "changeType", ICCardToOperate.Id.ToString()
            );
            if (beginningTime != null)
                requestData.Add("startDate", beginningTime.Value.GetUnixTimeInMilliseconds().ToString());
            if (expirationTime != null)
                requestData.Add("endDate", expirationTime.Value.GetUnixTimeInMilliseconds().ToString());

            return PostRequest("changePeriod", requestData);
        }
    }
}
