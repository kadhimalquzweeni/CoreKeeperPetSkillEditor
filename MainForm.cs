using CoreKeeperPetSkillEditor.Data;
using CoreKeeperPetSkillEditor.Models;
using CoreKeeperPetSkillEditor.Models.Pet;
using CoreKeeperPetSkillEditor.Services;

namespace CoreKeeperPetSkillEditor;

public partial class MainForm : Form
{
    private readonly List<ComboBox> _talentComboBoxes;
    private readonly SaveDataManager _saveDataManager =
    new();
    private List<Pet> _pets = [];

    public MainForm()
    {
        InitializeComponent();

        _talentComboBoxes =
        [
            cmbTalent1,
            cmbTalent2,
            cmbTalent3,
            cmbTalent4,
            cmbTalent5,
            cmbTalent6,
            cmbTalent7,
            cmbTalent8,
            cmbTalent9
        ];

        LoadTalents();
    }

    private void LoadTalents()
    {
        foreach (var comboBox in _talentComboBoxes)
        {
            comboBox.DataSource =
                new List<PetTalentDefinition>(PetTalentData.All);

            comboBox.DisplayMember =
                nameof(PetTalentDefinition.DisplayName);

            comboBox.ValueMember =
                nameof(PetTalentDefinition.Id);

            comboBox.SelectedIndex = -1;
        }
    }

    private void btnLoadSave_Click(
        object sender,
        EventArgs e)
    {
        using var openFileDialog =
            new OpenFileDialog
            {
                Filter =
                    "Core Keeper character saves (*.json)|*.json"
            };

        if (openFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        try
        {
            _pets =
                _saveDataManager.LoadSaveFile(
                    openFileDialog.FileName);

            lblLoadedSave.Text =
                Path.GetFileName(
                    openFileDialog.FileName);

            cmbPets.DataSource = null;
            cmbPets.DataSource = _pets;

            if (_pets.Count == 0)
            {
                MessageBox.Show(
                    "No pets were found in this character save.",
                    "No Pets",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to load save:\n\n{ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void cmbPets_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
        if (cmbPets.SelectedItem is not Pet selectedPet)
        {
            return;
        }

        try
        {
            List<PetTalent> talents =
                selectedPet.Talents;

            for (
                int i = 0;
                i < _talentComboBoxes.Count;
                i++)
            {
                if (i >= talents.Count)
                {
                    _talentComboBoxes[i].SelectedIndex = -1;
                    continue;
                }

                PetTalent petTalent = talents[i];

                var talentDefinition =
                    PetTalentData.All.FirstOrDefault(t =>
                        t.Id == petTalent.Talent);

                _talentComboBoxes[i].SelectedItem =
                    talentDefinition;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to load pet talents:\n\n{ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnSaveToCoreKeeper_Click(
        object sender,
        EventArgs e)
    {
        if (cmbPets.SelectedItem
            is not Pet selectedPet)
        {
            MessageBox.Show(
                "Please select a pet first.",
                "No Pet Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            // Read all 9 selected talents.
            List<PetTalent> newTalents =
                GetSelectedTalents();

            // Replace the pet's actual talents.
            selectedPet.Talents = newTalents;

            // Save the modified pet to Core Keeper.
            _saveDataManager.SavePet(selectedPet);

            MessageBox.Show(
                "The pet talents were saved successfully!\n\n" +
                "A backup of the original save was also created.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to save pet talents:\n\n{ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private List<PetTalent> GetSelectedTalents()
    {
        var selectedTalents =
            new List<PetTalent>();

        foreach (ComboBox comboBox
                 in _talentComboBoxes)
        {
            if (comboBox.SelectedItem
                is not PetTalentDefinition talent)
            {
                throw new InvalidOperationException(
                    "Please select a talent for all 9 slots.");
            }

            selectedTalents.Add(
                new PetTalent(
                    talent.Id,
                    1));
        }

        return selectedTalents;
    }

    private void btnCopyFirstTalentToAll_Click(
        object sender,
        EventArgs e)
    {
        if (_talentComboBoxes.Count == 0)
        {
            return;
        }

        ComboBox firstTalentComboBox =
            _talentComboBoxes[0];

        if (firstTalentComboBox.SelectedItem == null)
        {
            MessageBox.Show(
                "Please select a talent in Slot 1 first.",
                "No Talent Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // Copy Slot 1's selected talent to every slot.
        foreach (ComboBox comboBox in _talentComboBoxes)
        {
            comboBox.SelectedItem =
                firstTalentComboBox.SelectedItem;
        }
    }
}