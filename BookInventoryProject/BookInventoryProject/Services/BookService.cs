namespace BookInventoryProject.Services
{
    using BookInventoryProject.Models;
    using BookInventoryProject.Repositories;

    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
            => _repository.GetAllAsync();

        public Task<Book?> GetBookByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<Book> CreateBookAsync(Book book)
            => _repository.AddAsync(book);

        public async Task<Book?> UpdateBookAsync(int id, Book book)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Publisher = book.Publisher;
            existing.PublishedDate = book.PublishedDate;
            existing.Email = book.Email;
            existing.Price = book.Price;
            existing.Description = book.Description;

            return await _repository.UpdateAsync(existing);
        }

        public Task<bool> DeleteBookAsync(int id)
            => _repository.DeleteAsync(id);
    }
}