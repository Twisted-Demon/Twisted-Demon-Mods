namespace Wasteland_Waves.Source.NetPackages;

public class NetPackageVehicleRadioSendData : NetPackage
{
    private string _currentSong = string.Empty;
    private string _currentStation = string.Empty;
    private float _currentTime;
    private bool _isMuted;
    private int _vehicleEntityId;

    public NetPackageVehicleRadioSendData Setup(int vehicleEntityId, string currentStation, string currentSong,
        float currentTime, bool isMuted)
    {
        _vehicleEntityId = vehicleEntityId;
        _currentStation = currentStation;
        _currentSong = currentSong;
        _currentTime = currentTime;
        _isMuted = isMuted;
        
        return this;
    }

    public override void read(PooledBinaryReader reader)
    {
        _vehicleEntityId = reader.ReadInt32();
        _currentStation = reader.ReadString();
        _currentSong = reader.ReadString();
        _currentTime = (float)reader.ReadDouble();
        _isMuted = reader.ReadBoolean();
    }

    public override void write(PooledBinaryWriter writer)
    {
        base.write(writer);

        writer.Write(_vehicleEntityId);
        writer.Write(_currentStation);
        writer.Write(_currentSong);
        writer.Write((double)_currentTime);
        writer.Write(_isMuted);
    }

    public override void ProcessPackage(World world, GameManager gameManager)
    {
        if (world.GetEntity(_vehicleEntityId) is not EntityVehicle vehicle)
            return;

        var vehicleRadio = vehicle.GetComponent<VehicleRadioComponent>();
        if (vehicleRadio == null)
            return;

        vehicleRadio.UpdateRadio(_currentStation);
        vehicleRadio.SetMute(_isMuted);
    }

    public override int GetLength()
    {
        return 0;
    }
}