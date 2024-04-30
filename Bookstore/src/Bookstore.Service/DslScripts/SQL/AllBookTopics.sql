SELECT
    b.ID,
    b.Title,
    NumberOfTopics = COUNT(bt.ID)
FROM
    Bookstore.Book b
    LEFT JOIN Bookstore.BookTopic bt ON bt.BookID = b.ID
GROUP BY
    b.ID,
    b.Title