using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using CircusTrain.classes;

namespace CircusTrain
{
    public partial class Form1 : Form
    {
        private List<Animal> Animals { get; } = new List<Animal>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddAnimalBTN_Click(object sender, EventArgs e)
        {
            //Check wich radiobutton is selected in both the group boxes and make a new animal size int
            var sizeButton = AnimalSizeGB.Controls.OfType<RadioButton>()
                                .FirstOrDefault(r => r.Checked);
            var dietButton = AnimalDietGB.Controls.OfType<RadioButton>()
                                .FirstOrDefault(r => r.Checked);


            //Cast the given strings from the radiobuttons in to a diet and size enum
            Diet dietName = (Diet)Diet.Parse(typeof(Diet), dietButton.Text);
            AnimalSize animalSize = (AnimalSize)Enum.Parse(typeof(AnimalSize), sizeButton.Text);

            //Make a new animal and add it to the List View/List Box
            Animal animal = new Animal(animalSize, dietName);
            //AnimalLV.Items.Add($"Animal size: {animal.AnimalSize} and diet: {animal.Diet}");
            AnimalLB.Items.Add($"Animal size: {animal.AnimalSize} and diet: {animal.Diet}");
            Animals.Add(animal);

        }

        private void DivdeAnimalsBTN_Click(object sender, EventArgs e)
        {
            //Make a new train
            Train train = new Train();
            //Start dividing animals 
            var divdeResult = train.DivideAnimals(Animals);
        }
    }
}
