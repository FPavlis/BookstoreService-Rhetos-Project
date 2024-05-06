SELECT
    p.ID,
    p.Name
FROM
    Bookstore.Person p
GROUP BY
    p.ID,
    p.Name