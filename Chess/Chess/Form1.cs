using Chess.Pieces;

namespace Chess
{
    public partial class mainWindow : Form
    {
        private PieceColor _pickedColor;

        private Board board;
        private Panel boardPanel;
        private TextBox movesTb;
        private Button[,] cells;
        private Button _selectedPiece;
        private Random _rand;

        public mainWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Width = 600;
            this.Height = 400;
            board = Board.GetInstance();
            cells = new Button[8, 8];
            _rand = new Random();
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
            this.Width = 1100;
            this.Height = 900;
            this.Controls.Clear();
            this.Refresh();
            boardPanel = new Panel()
            {
                Width = 800,
                Height = 800,
                BackColor = Color.LightGray,
                Location = new Point((int)(this.Width*0.02), (int)(this.Height * 0.02))
            };
            movesTb = new TextBox()
            {
                Height = 800,
                Width = 200,
                BackColor = Color.DarkGray,
                Location = new Point((int)(this.Width * 0.02 + 820), (int)(this.Height * 0.02)),
                Multiline = true,
                ReadOnly = true
            };
            this.Controls.Add(boardPanel);
            this.Controls.Add(movesTb);
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    cells[i, j] = new Button()
                    {
                        Width = 100,
                        Height = 100,
                        Location = new Point(100 * j, 100 * i),
                        Tag = $"{i}|{j}"
                    };
                    cells[i, j].Click += cell_Click;
                    boardPanel.Controls.Add(cells[i, j]);
                }
            }
            DrawColors();
            DrawPieces();
        }

        private void DrawPieces()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    cells[i, j].Text = board.Cells[i, j].Piece != null ? board.Cells[i, j].Piece.ToString() : string.Empty;
                }
            }
        }

        private void DrawColors()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(i % 2 == 0)
                    {
                        cells[i,j].BackColor = j % 2 == 0 ? Color.LightYellow : Color.SaddleBrown;
                    }
                    else
                    {
                        cells[i, j].BackColor = j % 2 != 0 ? Color.LightYellow : Color.SaddleBrown;
                    }
                }
            }
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
            board.SetupBoardForColor(_pickedColor);
            RenderSingleplayer();
        }

        private void cell_Click(object sender, EventArgs e)
        {
            board.playerMove = PlayerType.Human;
            Button pressedButton = (Button)sender;
            if(pressedButton.BackColor == Color.Cyan)
            {
                MovePiece(pressedButton);
                DrawColors();
                DrawPieces();
                DisableButtons();
                board.playerMove = PlayerType.Computer;
                ComputerMove();
            }
            else
            {
                DrawColors();
                if(pressedButton.Text != string.Empty)
                {
                    var positions = pressedButton.Tag.ToString().Split('|');
                    var row = Int16.Parse(positions[0]); var col = Int16.Parse(positions[1]);
                    if (board.Cells[row,col].Piece.color == _pickedColor)
                    {
                        var pseudoLegalMoves = board.Cells[row, col].Piece.CalculateLegalMoves();
                        foreach (var move in pseudoLegalMoves)
                        {
                            var wholeMove = move.Split('|');
                            var position = wholeMove[1].Split(',');
                            int x = Int16.Parse(position[1]); int y = Int16.Parse(position[0]);
                            cells[y, x].BackColor = Color.Cyan;
                        }
                        _selectedPiece = pressedButton;
                    }
                }
                else
                {
                    _selectedPiece = null;
                }
            }
        }

        // HELPERS

        private void MovePiece(Button locationToMove)
        {
            var positionFrom = _selectedPiece.Tag.ToString().Split('|');
            var positionTo = locationToMove.Tag.ToString().Split('|');
            int positionFromX = Int16.Parse(positionFrom[1]); int positionFromY = Int16.Parse(positionFrom[0]);
            int positionToX = Int16.Parse(positionTo[1]); int positionToY = Int16.Parse(positionTo[0]);
            board.MovePiece(positionFromX, positionFromY, positionToX, positionToY);
        }

        private void MovePieceForComputer(int positionFromX, int positionFromY, int positionToX, int positionToY)
        {
            board.MovePiece(positionFromX, positionFromY, positionToX, positionToY);
        }

        private void ComputerMove()
        {
            List<string> legalMoves = new List<string>();
            if (_pickedColor == PieceColor.White)
            {
                legalMoves = board.CalculateAllLegalMovesByColor(PieceColor.Black);
            }
            else
            {
                legalMoves = board.CalculateAllLegalMovesByColor(PieceColor.White);
            }
            string selectedMove = legalMoves[_rand.Next(legalMoves.Count)];
            var moveFrom = selectedMove.Split('|')[0].Split(',');
            var moveTo = selectedMove.Split('|')[1].Split(',');
            int moveFromX = Int16.Parse(moveFrom[1]); int moveFromY = Int16.Parse(moveFrom[0]);
            int moveToX = Int16.Parse(moveTo[1]); int moveToY = Int16.Parse(moveTo[0]);
            MovePieceForComputer(moveFromX, moveFromY, moveToX, moveToY);
            DrawPieces();
            EnableButtons();
        }

        private void DisableButtons()
        {
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    cells[i, j].Enabled = false;
                }
            }
        }

        private void EnableButtons()
        {
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    cells[i, j].Enabled = true;
                }
            }
        }
    }
}