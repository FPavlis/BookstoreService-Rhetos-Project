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
