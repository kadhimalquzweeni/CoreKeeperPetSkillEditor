using System.Text.Json;

namespace CoreKeeperPetSkillEditor.Models.Pet;

public class PetTalent
{
    public int Talent { get; set; }

    public int Points { get; set; }

    public PetTalent()
    {
    }

    public PetTalent(int talent, int points)
    {
        Talent = talent;
        Points = points;
    }

    public PetTalent(string json)
    {
        var talent = JsonSerializer.Deserialize<PetTalent>(json);

        if (talent is null)
        {
            throw new InvalidOperationException(
                "Unable to read pet talent.");
        }

        Talent = talent.Talent;
        Points = talent.Points;
    }

    public string ToJsonString()
    {
        return JsonSerializer.Serialize(this);
    }
}