using Chess.Pieces;

namespace Chess
{
    public partial class mainWindow : Form
    {
        private PieceColor _pickedColor;

        public mainWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Width = 600;
            this.Height = 400;
            RenderMenu();
        }


        
        // RENDERING
        private void RenderMenu()
        {
            Button singleplayerBtn = new Button()
            {
                Text = "Singleplayer",
                Name = "singleplayerBtn",
                Width = 200,
                Height = 50,
                Location = new Point(this.Width/2 - 100, (int)(this.Height * 0.2))
            };
            singleplayerBtn.Click += singleplayer_Click;
            Button multiplayerBtn = new Button()
            {
                Text = "Multiplayer",
                Name = "multiplayerBtn",
                Width = 200,
                Height = 50,
                Location = new Point(this.Width / 2 - 100, (int)(this.Height * 0.35))
            };
            Button exitBtn = new Button()
            {
                Text = "Exit",
                Name = "singlePlayerBtn",
                Width = 200,
                Height = 50,
                Location = new Point(this.Width / 2 - 100, (int)(this.Height * 0.5))
            };
            Controls.Add(singleplayerBtn);
            Controls.Add(multiplayerBtn);
            Controls.Add(exitBtn);
        }

        private void RenderSingleplayerMenu()
        {
            this.Refresh();
            this.Controls.Clear();
            Button whiteBtn = new Button()
            {
                Text = "White",
                Name = "whiteBtn",
                Width = 200,
                Height = 50,
                Location = new Point(this.Width / 2 - 100, (int)(this.Height * 0.2))
            };
            Button blackBtn = new Button()
            {
                Text = "Black",
                Name = "blackBtn",
                Width = 200,
                Height = 50,
                Location = new Point(this.Width / 2 - 100, (int)(this.Height * 0.35))
            };
            whiteBtn.Click += colorPick_Click;
            blackBtn.Click += colorPick_Click;
            this.Controls.Add(whiteBtn);
            this.Controls.Add(blackBtn);
        }

        private void RenderSingleplayer()
        {

        }

        // BUTTON EVENTS

        private void singleplayer_Click(object sender, EventArgs e)
        {
            RenderSingleplayerMenu();
        }

        private void colorPick_Click(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            if (selected.Text.Equals("White"))
            {
                _pickedColor = PieceColor.White;
            }
            else
            {
                _pickedColor = PieceColor.Black;
            }
            Table table = Table.GetInstance();
            table.SetupTableForColor(_pickedColor);
        }
    }
}