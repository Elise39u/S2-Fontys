namespace CircusTrain
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.smallRB = new System.Windows.Forms.RadioButton();
            this.NormalRB = new System.Windows.Forms.RadioButton();
            this.largeRB = new System.Windows.Forms.RadioButton();
            this.hebivoreRB = new System.Windows.Forms.RadioButton();
            this.carnivoreRB = new System.Windows.Forms.RadioButton();
            this.AddAnimalBTN = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.AnimalDietGB = new System.Windows.Forms.GroupBox();
            this.AnimalSizeGB = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AnimalLB = new System.Windows.Forms.ListBox();
            this.divdeAnimalsBTN = new System.Windows.Forms.Button();
            this.AnimalDietGB.SuspendLayout();
            this.AnimalSizeGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // smallRB
            // 
            this.smallRB.AutoSize = true;
            this.smallRB.Location = new System.Drawing.Point(6, 19);
            this.smallRB.Name = "smallRB";
            this.smallRB.Size = new System.Drawing.Size(50, 17);
            this.smallRB.TabIndex = 1;
            this.smallRB.TabStop = true;
            this.smallRB.Text = "Small";
            this.smallRB.UseVisualStyleBackColor = true;
            // 
            // NormalRB
            // 
            this.NormalRB.AutoSize = true;
            this.NormalRB.Location = new System.Drawing.Point(6, 42);
            this.NormalRB.Name = "NormalRB";
            this.NormalRB.Size = new System.Drawing.Size(58, 17);
            this.NormalRB.TabIndex = 2;
            this.NormalRB.TabStop = true;
            this.NormalRB.Text = "Normal";
            this.NormalRB.UseVisualStyleBackColor = true;
            // 
            // largeRB
            // 
            this.largeRB.AutoSize = true;
            this.largeRB.Location = new System.Drawing.Point(6, 65);
            this.largeRB.Name = "largeRB";
            this.largeRB.Size = new System.Drawing.Size(40, 17);
            this.largeRB.TabIndex = 3;
            this.largeRB.TabStop = true;
            this.largeRB.Text = "Big";
            this.largeRB.UseVisualStyleBackColor = true;
            // 
            // hebivoreRB
            // 
            this.hebivoreRB.AutoSize = true;
            this.hebivoreRB.Location = new System.Drawing.Point(6, 57);
            this.hebivoreRB.Name = "hebivoreRB";
            this.hebivoreRB.Size = new System.Drawing.Size(71, 17);
            this.hebivoreRB.TabIndex = 5;
            this.hebivoreRB.TabStop = true;
            this.hebivoreRB.Text = "Herbivore";
            this.hebivoreRB.UseVisualStyleBackColor = true;
            // 
            // carnivoreRB
            // 
            this.carnivoreRB.AutoSize = true;
            this.carnivoreRB.Location = new System.Drawing.Point(6, 34);
            this.carnivoreRB.Name = "carnivoreRB";
            this.carnivoreRB.Size = new System.Drawing.Size(70, 17);
            this.carnivoreRB.TabIndex = 4;
            this.carnivoreRB.TabStop = true;
            this.carnivoreRB.Text = "Carnivore";
            this.carnivoreRB.UseVisualStyleBackColor = true;
            // 
            // AddAnimalBTN
            // 
            this.AddAnimalBTN.Location = new System.Drawing.Point(27, 291);
            this.AddAnimalBTN.Name = "AddAnimalBTN";
            this.AddAnimalBTN.Size = new System.Drawing.Size(170, 23);
            this.AddAnimalBTN.TabIndex = 9;
            this.AddAnimalBTN.Text = "Add animal ";
            this.AddAnimalBTN.UseVisualStyleBackColor = true;
            this.AddAnimalBTN.Click += new System.EventHandler(this.AddAnimalBTN_Click);
            // 
            // AnimalDietGB
            // 
            this.AnimalDietGB.Controls.Add(this.carnivoreRB);
            this.AnimalDietGB.Controls.Add(this.hebivoreRB);
            this.AnimalDietGB.Location = new System.Drawing.Point(27, 161);
            this.AnimalDietGB.Name = "AnimalDietGB";
            this.AnimalDietGB.Size = new System.Drawing.Size(200, 100);
            this.AnimalDietGB.TabIndex = 10;
            this.AnimalDietGB.TabStop = false;
            this.AnimalDietGB.Text = "Animal Diet";
            // 
            // AnimalSizeGB
            // 
            this.AnimalSizeGB.Controls.Add(this.smallRB);
            this.AnimalSizeGB.Controls.Add(this.NormalRB);
            this.AnimalSizeGB.Controls.Add(this.largeRB);
            this.AnimalSizeGB.Location = new System.Drawing.Point(27, 39);
            this.AnimalSizeGB.Name = "AnimalSizeGB";
            this.AnimalSizeGB.Size = new System.Drawing.Size(200, 100);
            this.AnimalSizeGB.TabIndex = 11;
            this.AnimalSizeGB.TabStop = false;
            this.AnimalSizeGB.Text = "Animal Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Animals List";
            // 
            // AnimalLB
            // 
            this.AnimalLB.FormattingEnabled = true;
            this.AnimalLB.Location = new System.Drawing.Point(341, 39);
            this.AnimalLB.Name = "AnimalLB";
            this.AnimalLB.Size = new System.Drawing.Size(406, 394);
            this.AnimalLB.TabIndex = 13;
            // 
            // divdeAnimalsBTN
            // 
            this.divdeAnimalsBTN.Location = new System.Drawing.Point(27, 338);
            this.divdeAnimalsBTN.Name = "divdeAnimalsBTN";
            this.divdeAnimalsBTN.Size = new System.Drawing.Size(170, 23);
            this.divdeAnimalsBTN.TabIndex = 14;
            this.divdeAnimalsBTN.Text = "Divide Animals";
            this.divdeAnimalsBTN.UseVisualStyleBackColor = true;
            this.divdeAnimalsBTN.Click += new System.EventHandler(this.DivdeAnimalsBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.divdeAnimalsBTN);
            this.Controls.Add(this.AnimalLB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnimalSizeGB);
            this.Controls.Add(this.AnimalDietGB);
            this.Controls.Add(this.AddAnimalBTN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.AnimalDietGB.ResumeLayout(false);
            this.AnimalDietGB.PerformLayout();
            this.AnimalSizeGB.ResumeLayout(false);
            this.AnimalSizeGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton smallRB;
        private System.Windows.Forms.RadioButton NormalRB;
        private System.Windows.Forms.RadioButton largeRB;
        private System.Windows.Forms.RadioButton hebivoreRB;
        private System.Windows.Forms.RadioButton carnivoreRB;
        private System.Windows.Forms.Button AddAnimalBTN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox AnimalDietGB;
        private System.Windows.Forms.GroupBox AnimalSizeGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox AnimalLB;
        private System.Windows.Forms.Button divdeAnimalsBTN;
    }
}

