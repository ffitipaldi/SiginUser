--Seleciona uma lista por data de agendas
Set Language PORTUGUESE;
Select	convert(DateTime, a.DtConsulta, 103) as DataConsulta
From (
	select convert(varchar(10),DataAgenda, 111) as DtConsulta
	from Agendas
	where CpfProfissional = '30381498883'
	group by convert(varchar(10),DataAgenda, 111)
) as a
order by a.DtConsulta
