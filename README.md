# BookstoreService-Rhetos-Project
A Rhetos Project about a bookstore library.

## DAY 1
### Nested vs Flat Statements

```
NESTED:

Module Bookstore
{
   Entity Book
   {
      ShortString Code { AutoCode; }
      ShortString Title;
      Integer NumberOfPages;

      ItemFilter CommonMisspelling 'book => book.Title.Contains("curiousity")';
      InvalidData CommonMisspelling 'It is not allowed to enter misspelled word "curiousity"';

      Logging;
   }
}

FLAT:

Module Bookstore;
   Entity Bookstore.Book;
   ShortString Bookstore.Book.Code;
      AutoCode Bookstore.Book.Code;
   ShortString Bookstore.Book.Title;
   Integer Bookstore.Book.NumberOfPages;
   ItemFilter Bookstore.Book.CommonMisspelling 'book => book.Title.Contains("curiousity")';
   InvalidData BookStore.Book.CommonMisspelling 'It is not allowed to enter misspelled word "curiousity"';
   Logging BookStore.Book;
```
## DAY 2
### LINQPad

Load:
```
repository.Bookstore.Book.Load().Dump();
```

Query:
```
repository.Bookstore.Book.Query().Select(b => new {Title = b.Title, Author = b.Author.Name}).ToList().Dump();
repository.Bookstore.Book.Query().Select(b => new {Title = b.Title, Author = b.Author.Name}).ToString().Dump();
```

Action:
```
   var actionParameter = new Bookstore.InsertSpecificBooks
	{
           NumberOfBooks = 2,
           Title = "Tom and Jerry"
	};

   repository.Bookstore.InsertSpecificBooks.Execute(actionParameter);
   scope.CommitAndClose();
```
