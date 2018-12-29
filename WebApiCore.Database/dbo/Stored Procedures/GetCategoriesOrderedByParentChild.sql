-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetCategoriesOrderedByParentChild
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    WITH q(CategoryId, CategoryName, ParentId, hierarchyOrder) AS
(
	SELECT p.CategoryId, p.CategoryName, p.ParentId, 
		CAST(ROW_NUMBER() OVER (ORDER BY p.CategoryId) AS VARCHAR(20)) AS hierarchyOrder
	FROM dbo.Categories p
	WHERE p.ParentId IS NULL
	UNION ALL
		SELECT c.CategoryId, c.CategoryName, c.ParentId, 
			q.hierarchyOrder + '.' 
			+ CAST(ROW_NUMBER() OVER (PARTITION BY c.ParentId ORDER BY c.ParentId) AS VARCHAR(20))
		FROM dbo.Categories c
		JOIN q ON c.ParentId=q.CategoryId
	)
	SELECT * FROM q ORDER BY hierarchyOrder
END
