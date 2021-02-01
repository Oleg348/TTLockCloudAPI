using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class GatewayCloudAPI : TTLockCloudAPI, IGatewayCloudAPI
    {
        public GatewayCloudAPI(Uri serverUri = null)
            : base("v3/gateway/", serverUri)
        { }

        public Gateway GatewayToOperate { get; set; }

        public async Task<PageResult<UserGateway>> GetUserGateways(int page = 1, int pageSize = 20)
        {
            var dto = await PostRequest<PageResultDto<UserGatewayDto>>(
                "list",
                CreateDictionary(
                    "pageNo", page.ToString(),
                    "pageSize", pageSize.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(() => dto.ToPageResult(
                g => new UserGateway(
                    g.gatewayId,
                    g.gatewayMac,
                    g.gatewayVersion,
                    g.networkName,
                    g.lockNum,
                    g.isOnline != 0
                )
            ));
        }

        public async Task<IList<LockGateway>> GetLockGateways(int lockId)
        {
            var dto = await PostRequest<PageResultDto<LockGatewayDto>>(
                "listByLock",
                CreateDictionary(
        "lockId", lockId.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(
                () => dto.list?.Select(
                    d => new LockGateway(
                        d.gatewayId,
                        d.gatewayMac,
                        d.rssi,
                        d.rssiUpdateDate.GetDateTimeFromUnixMilliseconds()
                    )
                ).ToList() ?? new List<LockGateway>()
            );
        }

        public async Task<IList<GatewayLock>> GetGetewayLocks()
        {
            var dto = await PostRequest<PageResultDto<GatewayLockDto>>(
                "listLock",
                CreateDictionary(
                    "gatewayId", GatewayToOperate.Id.ToString()
                )
            ).ConfigureAwait(false);

            return ConvertDto(
                () => dto.list?.Select(
                    l => new GatewayLock(
                        l.lockId,
                        l.lockMac,
                        l.lockName,
                        l.lockAlias,
                        l.rssi,
                        l.updateDate.GetDateTimeFromUnixMilliseconds()
                    )
                ).ToList() ?? new List<GatewayLock>()
            );
        }

        public Task TransferGatewaysToOtherUser(string receiverUsername, int[] gatewaysIds)
        {
            VerifyUsername(receiverUsername);

            return PostRequest("transfer",
                CreateDictionary(
                    "receiverUsername", receiverUsername,
                    "gatewayIdList", gatewaysIds.SerializeToJson()
                )
            );
        }

        public Task TransferGatewayToOtherUser(string receiverUsername)
        {
            return TransferGatewaysToOtherUser(receiverUsername, new[] { GatewayToOperate.Id });
        }

        public Task DeleteGateway()
        {
            return PostRequest("delete",
                CreateDictionary(
                    "gatewayId", GatewayToOperate.Id.ToString()
                )
            );
        }

        public async Task<GatewayInitResult> IsGatewayInitSuccess()
        {
            var dto = await PostRequest<GatewayInitResultDto>(
                "isInitSuccess",
                CreateDictionary(
                    "gatewayNetMac", GatewayToOperate.MacAddress
                )
            ).ConfigureAwait(false);

            return new GatewayInitResult(dto.gatewayId);
        }

        public Task UploadGatewayInfo(GatewayRouterModelInfo deviceInfo, WifiInfo wifiInfo)
        {
            return PostRequest(
                "uploadDetail",
                CreateDictionary(
                    "gatewayId", GatewayToOperate.Id.ToString(),
                    "modelNum", deviceInfo.Model,
                    "hardwareRevision", deviceInfo.HardwareRevision,
                    "firmwareRevision", deviceInfo.FirmwareRevision,
                    "networkName", wifiInfo.WifiName
                )
            );
        }

        public async Task<CheckGatewayUpdatesResult> CheckGatewayUpdates()
        {
            var dto = await PostRequest<CheckGatewayUpdatesResultDto>("upgradeCheck",
                CreateDictionary(
                    "gatewayId", GatewayToOperate.Id.ToString()
                )
            ).ConfigureAwait(false);

            return new CheckGatewayUpdatesResult(dto.needUpgrade == 1, dto.firmwareInfo);
        }

        public Task SetGatewayInUpgradeMode()
        {
            return PostRequest("setUpgradeMode",
                CreateDictionary(
                    "gatewayId", GatewayToOperate.Id.ToString()
                )
            );
        }
    }
}
