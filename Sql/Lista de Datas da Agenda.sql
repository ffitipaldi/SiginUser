select convert(varchar(10),DataAgenda, 103) as DataConsulta
from Agendas
where CpfProfissional = '30381498883'
group by convert(varchar(10),DataAgenda, 103)
order by DataConsulta