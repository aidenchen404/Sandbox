

using System;
using System.Collections.Generic;

namespace Sandbox
{
    public static class Desk
    {
        #region Book
        public static IEnumerable<BookModel> LoadBooks()
        {
            return BookRepository.GetBookList();
        }
        public static BookModel LoadBook(Guid bookId)
        {
            return  BookRepository.GetBook(bookId);
        }

        public static BookModel CreateBook(int cornerTop, int cornerLeft)
        {
            var book = new BookModel()
            {
                Id = Guid.NewGuid(),
                Name = "A New Book",
                Desc = DateTime.Today.ToLongDateString(),
                Width = cornerLeft,
                Height = cornerTop
            };

            var saved = BookRepository.SaveBook(book, true);
            return saved;
        }

        public static BookModel UpdateBook(BookModel book)
        {
            var saved = BookRepository.SaveBook(book, false);
            return saved;
        }

        public static bool DeleteBook(Guid bookId)
        {
            PaperRepository.DeletePapersByBookId(bookId);
            StickerRepository.DeleteStickersByBookId(bookId);
            BookRepository.DeleteBook(bookId);

            return true;
        }
        #endregion Book
        #region Sticker
        public static List<StickerModel> LoadStickers(Guid bookId)
        {
            return StickerRepository.GetStickerListByBookId(bookId);
        }

        public static StickerModel SaveSticker(StickerModel sticker)
        {
            if (sticker.Id == Guid.Empty)
            {
                sticker.Id = Guid.NewGuid();
                return StickerRepository.SaveSticker(sticker, true);
            }

            return StickerRepository.SaveSticker(sticker,false);
        }

        public static void DeleteSticker(Guid stickerId)
        {
            PaperRepository.DeletePapersByStickerId(stickerId);
            StickerRepository.DeleteSticker(stickerId);
        }

        #endregion Sticker

        #region Paper
        public static List<PaperModel> LoadPapers(Guid stickerId)
        {
            return PaperRepository.GetPaperListByStickerId(stickerId);
        }
        public static PaperModel LoadPaper(Guid paperId)
        {
            return PaperRepository.GetPaper(paperId);
        }
        public static PaperModel SavePaper(PaperModel paper)
        {
            if (paper.Id == Guid.Empty)
            {
                paper.Id = Guid.NewGuid();
                return PaperRepository.SavePaper(paper, true);
            }

            return PaperRepository.SavePaper(paper, false);
        }

        public static void DeletePaper(Guid paperId)
        {
            PaperRepository.DeletePaper(paperId);
            return;
        }

        #endregion Paper
    }
}

