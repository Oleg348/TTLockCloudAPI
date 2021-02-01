namespace OrbitaTech.TTLock
{
    public class LockVersion
    {
        public LockVersion(int protocolType, int protocolVersion, int scene, int groupId, int orgId)
        {
            ProtocolType = protocolType;
            ProtocolVersion = protocolVersion;
            Scene = scene;
            GroupId = groupId;
            OrgId = orgId;
        }

        public int ProtocolType { get; }

        public int ProtocolVersion { get; }

        public int Scene { get; }

        public int GroupId { get; }

        public int OrgId { get; }
    }
}
