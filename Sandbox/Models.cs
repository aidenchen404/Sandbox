using System;

namespace Sandbox
{
    public class BookModel
    {

        public Guid Id;
        public string IdString => Id.ToString();
        public string Name;
        public string Desc;
        public int Width;
        public int Height;
    }

    public class StickerModel
    {
        const int StickerButtonWidth = 80;
        const int StickerButtonHeight = 20;

        public StickerModel(Guid bookId)
        {
            Name = "New Sticker";
            PosX = 100;
            PosY = 100;
            ForecolorA = 255;
            ForecolorR = 1;
            ForecolorG = 1;
            ForecolorB = 1;
            BackcolorA = 255;
            BackcolorR = 170;
            BackcolorG = 220;
            BackcolorB = 210;
            Width = StickerButtonWidth;
            Height = StickerButtonHeight;
            BookId = bookId;
        }

        public Guid Id;
        public string Name;
        public string Desc;
        public string Tag;
        public int PosX;
        public int PosY;
        public int ForecolorA;
        public int ForecolorR;
        public int ForecolorG;
        public int ForecolorB;
        public int BackcolorA;
        public int BackcolorR;
        public int BackcolorG;
        public int BackcolorB;
        public int Width;
        public int Height;
        public Guid BookId;

        public System.Drawing.Color ForeColor
        {
            get { return System.Drawing.Color.FromArgb(ForecolorA, ForecolorR, ForecolorG, ForecolorB); }
            set
            {
                ForecolorA = value.A;
                ForecolorR = value.R;
                ForecolorG = value.G;
                ForecolorB = value.B;
            }
        }


        public System.Drawing.Color BackColor
        {
            get { return System.Drawing.Color.FromArgb(BackcolorA, BackcolorR, BackcolorG, BackcolorB); }
            set
            {
                BackcolorA = value.A;
                BackcolorR = value.R;
                BackcolorG = value.G;
                BackcolorB = value.B;
            }
        }

        public StickerModel ShallowCopy()
        {
            var newModel = new StickerModel(this.BookId);

            newModel.Name = this.Name +"~";
            newModel.Desc = this.Desc;
            newModel.Tag = this.Tag;

            newModel.PosX = this.PosX + 20;
            newModel.PosY = this.PosY + 20;
            newModel.Width = this.Width;
            newModel.Height = this.Height;

            newModel.ForecolorA = this.ForecolorA;
            newModel.ForecolorR = this.ForecolorR;
            newModel.ForecolorG = this.ForecolorG;
            newModel.ForecolorB = this.ForecolorB;

            newModel.BackcolorA = this.BackcolorA;
            newModel.BackcolorR = this.BackcolorR;
            newModel.BackcolorG = this.BackcolorG;
            newModel.BackcolorB = this.BackcolorB;

            return newModel;
        }
    }

    public class PaperModel
    {
        public Guid Id;
        public string IdString => Id.ToString();
        public string Name;
        public string Desc;
        public string Text;
        public Guid StickerId;
    }

}
