insert into Transportations 
(
	RegNumber, 
	SourceStationId,
	DestinationStationId,
	EtsngId,
	GngId,
	CreateDate,
	Comment
) values
(
	'001',
	1,
	1,
	1,
	1,
	SYSDATETIME(),
	'Срочно'	
)

insert into Loads 
(
	TransportationId, 
	Volume, 
	[Count],
	Rate,
	Metod
) values
(
	1,
	50,
	2,
	110,
	0
)

insert into [Routes] 
(
	CarrierId, 
	RoadId,
	TransportationId
) values 
(
	1,
	1,
	1
)

insert into Expenses
(
	LoadId,
	RouteId,
	ExpenseTypeId,
	Value
)
values
(
	1,
	1,
	1,
	100
)
