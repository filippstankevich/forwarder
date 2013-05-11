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
	60,
	2,
	210,
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
	2,
	1
)

insert into [Routes] 
(
	CarrierId, 
	RoadId,
	TransportationId
) values 
(
	2,
	3,
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

insert into Expenses
(
	LoadId,
	RouteId,
	ExpenseTypeId,
	Value
)
values
(
	2,
	2,
	1,
	200
)

insert into Shipments
  (
  	TransportationId,	
	[Date],
	ArrivalDate,
	BillNumber,
	WagonNumber,
	[Weight],
	Capacity
  ) values 
  (
		1,
		'2013-05-05',
		null,
		'4534657',
		'0004656',
		50,
		50	
  )
  
  insert into Shipments
  (
  	TransportationId,	
	[Date],
	ArrivalDate,
	BillNumber,
	WagonNumber,
	[Weight],
	Capacity
  ) values 
  (
		1,
		'2013-05-05',
		null,
		'4534658',
		'0004657',
		60,
		60	
  )
