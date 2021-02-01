using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    public interface IGatewayCloudAPI : ITTLockCloudAPI
    {
        /// <summary>
        /// Router to work with.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        Gateway GatewayToOperate { get; set; }

        /// <summary>
        /// Get all user gateways.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized.</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<PageResult<UserGateway>> GetUserGateways(int page = 1, int pageSize = 20);

        /// <summary>
        /// Get all lock gateways.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"><see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized.</exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<IList<LockGateway>> GetLockGateways(int lockId);

        /// <summary>
        /// Get locks available for gateway.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized
        /// -or-
        /// <see cref="GatewayToOperate"/> wasn't initialized
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<IList<GatewayLock>> GetGetewayLocks();

        /// <summary>
        /// Delete user's gateway.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized
        /// -or-
        /// <see cref="GatewayToOperate"/> wasn't initialized
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task DeleteGateway();

        /// <summary>
        /// Transfer gateway to other user.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized
        /// -or-
        /// <see cref="GatewayToOperate"/> wasn't initialized
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task TransferGatewaysToOtherUser(string receiverUsername, int[] gatewaysIds);

        /// <summary>
        /// Transfer current gateway to other user.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized
        /// -or-
        /// <see cref="GatewayToOperate"/> wasn't initialized
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task TransferGatewayToOtherUser(string receiverUsername);

        /// <summary>
        /// Check if router successfully initialized.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized
        /// -or-
        /// <see cref="GatewayToOperate"/> wasn't initialized
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<GatewayInitResult> IsGatewayInitSuccess();

        /// <summary>
        /// Upload gateway info.
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <param name="wifiInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="deviceInfo"/> is null
        /// -or-
        /// <paramref name="wifiInfo"/> is null
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized
        /// -or-
        /// <see cref="GatewayToOperate"/> wasn't initialized
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task UploadGatewayInfo(GatewayRouterModelInfo deviceInfo, WifiInfo wifiInfo);

        /// <summary>
        /// Check if there is updates for gateway.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized
        /// -or-
        /// <see cref="GatewayToOperate"/> wasn't initialized
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task<CheckGatewayUpdatesResult> CheckGatewayUpdates();

        /// <summary>
        /// Set gateway into upgrade mode remotely.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// <see cref="ITTLockCloudAPI.UserToOperate"/> wasn't initialized
        /// -or-
        /// <see cref="GatewayToOperate"/> wasn't initialized
        /// </exception>
        /// <exception cref="HttpRequestException"/>
        /// <exception cref="TTLockAPIException"/>
        Task SetGatewayInUpgradeMode();
    }
}
