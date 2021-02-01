using System;
using System.Collections.Generic;
using System.Linq;

namespace OrbitaTech.TTLock
{
    internal static class APIHelpers
    {
        private static string VerifyMD5Password(string md5Password)
        {
            return md5Password
                .IsValid(md5Pass => md5Pass?.Length == 32, nameof(md5Password), "User md5 encrypted password must be not empty and consist of 32 chars");
        }

        /// <summary>
        /// Verify user name.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Input user name.</returns>
        /// <exception cref="ArgumentException">Invalid user name.</exception>
        public static string VerifyUsername(string username)
        {
            return username.IsNotNullOrEmpty(nameof(username));
        }

        /// <summary>
        /// Prepare md5 password.
        /// </summary>
        /// <param name="md5Password"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Invalid md5 encrypted password.</exception>
        public static string PrepareMD5Password(string md5Password)
        {
            VerifyMD5Password(md5Password);
            return md5Password.ToLowerInvariant();
        }

        /// <summary>
        /// Verify mac address.
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns>Input mac address.</returns>
        /// <exception cref="ArgumentException">Invalid mac address.</exception>
        public static string VerifyMacAddress(string macAddress)
        {
            return macAddress
                .IsValid(ma => !string.IsNullOrEmpty(ma), nameof(macAddress), "Mac address can't be null or empty");
        }

        /// <summary>
        /// Verify lock data.
        /// </summary>
        /// <param name="lockData"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Invalid lock data.</exception>
        public static string VerifyLockData(string lockData)
        {
            return lockData
                .IsValid(ld => !string.IsNullOrEmpty(ld), nameof(lockData), "Lock data can't be null or empty");
        }

        /// <summary>
        /// Verify lock pass code.
        /// </summary>
        /// <param name="passcode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Pass code is invalid.</exception>
        public static string VerifyPasscode(string passcode)
        {
            return passcode
                .IsValid(p => !string.IsNullOrEmpty(p) && int.TryParse(p, out _),
                nameof(passcode), "Pass code can't be null or empty or contain non-digits chars"
            );
        }

        /// <summary>
        /// Verify pass code info.
        /// </summary>
        /// <param name="passcodeInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Pass code info is invalid.</exception>
        public static string VerifyPasscodeInfo(string passcodeInfo)
        {
            return passcodeInfo
                .IsValid(p => !string.IsNullOrEmpty(p), nameof(passcodeInfo), "Pass code info can't be null or empty");
        }

        /// <summary>
        /// Verify IC card number.
        /// </summary>
        /// <param name="icCardNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">IC card number is invalid.</exception>
        public static string VerifyICCardNumber(string icCardNumber)
        {
            return icCardNumber
                .IsValid(p => !string.IsNullOrEmpty(p) && int.TryParse(p, out _),
                nameof(icCardNumber), "IC card number can't be null or empty or contain non-digits chars"
            );
        }

        /// <summary>
        /// Verify fingerprint number.
        /// </summary>
        /// <param name="fingerprintNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Fingerprint number is invalid.</exception>
        public static string VerifyFingerprintNumber(string fingerprintNumber)
        {
            return fingerprintNumber
                .IsValid(fpn => !string.IsNullOrEmpty(fpn), nameof(fingerprintNumber), "Fingerprint number can't be null or empty");
        }

        /// <summary>
        /// Get page result from page result dto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="dto"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="dto"/> is null
        /// -or-
        /// <paramref name="selector"/> is null
        /// </exception>
        public static PageResult<U> ToPageResult<T, U>(this PageResultDto<T> dto, Func<T, U> selector)
            where T : class, new()
        {
            dto.IsNotNull(nameof(dto));
            selector.IsNotNull(nameof(selector));

            return new PageResult<U>(
                dto.pageNo,
                dto.pages,
                dto.total,
                dto.list?.Select(selector).ToList() ?? new List<U>()
            );
        }

        public static LockVersion ToLockVersion(this LockVersionDto dto)
        {
            if (dto is null)
                return null;

            return new LockVersion(dto.protocolType, dto.protocolVersion, dto.scene, dto.groupId, dto.orgId);
        }
    }
}
