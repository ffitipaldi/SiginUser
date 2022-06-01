--Seleciona uma lista por data de agendas
Set Language PORTUGUESE;

Select  CAST(DataAgenda AS DATE) as DataConsulta
From Agendas
Where CpfProfissional = '25586149400'
Group by  CAST(DataAgenda AS DATE)
Order by DataConsulta
