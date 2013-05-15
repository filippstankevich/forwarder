CREATE FUNCTION dbo.ReportAllTransportations()
RETURNS @Result TABLE
(
	RegNumber nvarchar(max),
	CreateDate datetime,
	Comment nvarchar(max),
	Etsng nvarchar(max),
	Gng nvarchar(max),
	SourceStation nvarchar(max),
	DestinationStation nvarchar(max),
	PlanExp int,
	PlanPrice int,
	PlanProfit int,
	RealExp int, 
	RealPrice int,
	RealProfit int
)
AS
BEGIN
DECLARE @Temp TABLE 	
	(
		id int,
		RegNumber nvarchar(max),
		CreateDate datetime,
		Comment nvarchar(max),
		EtsngId int,
		Etsng nvarchar(max),
		GngId int, 
		Gng nvarchar(max),
		SourceStationId int,
		SourceStation nvarchar(max),
		DestinationStationId int,
		DestinationStation nvarchar(max),
		PlanExp int,
		PlanPrice int,
		PlanProfit int,
		RealExp int, 
		RealPrice int,
		RealProfit int
	)
	
	INSERT INTO @Temp
	(
		id,
		RegNumber,
		CreateDate,
		Comment,
		EtsngId,
		GngId,
		SourceStationId,
		DestinationStationId
	)
	SELECT
		Id,
		RegNumber,
		CreateDate,
		Comment,
		EtsngId,
		GngId,
		SourceStationId,
		DestinationStationId
	FROM Transportations
	
	UPDATE tmp
		SET tmp.Etsng = dct.Name + '(' + dct.Code + ')'
    FROM @Temp tmp
		JOIN Etsngs dct on dct.Id = tmp.EtsngId

	UPDATE tmp
		SET tmp.Gng = dct.Name + '(' + dct.Code + ')'
    FROM @Temp tmp
		JOIN Gngs dct on dct.Id = tmp.GngId
	
	UPDATE tmp
		SET tmp.SourceStation = dct.Name + '(' + dct.Code + ')'
    FROM @Temp tmp
		JOIN Stations dct on dct.Id = tmp.SourceStationId
	
	UPDATE tmp
		SET tmp.DestinationStation = dct.Name + '(' + dct.Code + ')'
    FROM @Temp tmp
		JOIN Stations dct on dct.Id = tmp.DestinationStationId
	
	INSERT INTO @Result
	(
		RegNumber,
		CreateDate,
		Comment,
		Etsng,
		Gng,
		SourceStation,
		DestinationStation
	)
	SELECT 
		RegNumber,
		CreateDate,
		Comment,
		Etsng,
		Gng,
		SourceStation,
		DestinationStation
	FROM @Temp
	
	RETURN
END
GO
