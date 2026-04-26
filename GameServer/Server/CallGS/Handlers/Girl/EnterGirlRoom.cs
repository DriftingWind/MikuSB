using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace MikuSB.GameServer.Server.CallGS.Handlers.Girl;

[CallGSApi("EnterGirlRoom")]
public class EnterGirlRoom : ICallGSHandler
{
    public async Task Handle(Connection connection, string param, ushort seqNo)
    {
        var req = JsonSerializer.Deserialize<EnterGirlRoomParam>(param);
        var response = new JsonObject
        {
            ["nCardId"] = req?.CardId ?? 1,
            ["nSkinId"] = req?.SkinId ?? 0,
            ["bOpen"] = true
        };

        await CallGSRouter.SendScript(connection, "EnterGirlRoom", response.ToJsonString());
    }
}

internal sealed class EnterGirlRoomParam
{
    [JsonPropertyName("nSkinId")]
    public int SkinId { get; set; }

    [JsonPropertyName("nCardID")]
    public uint CardId { get; set; }
}