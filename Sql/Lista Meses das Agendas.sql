--Lista de agendas por mes/Ano 

Set Language PORTUGUESE;
DECLARE @cpfProfissional as nvarchar(11) = '19346827807'

Select  CAST(substring(CONVERT(nvarchar(30), DataAgenda, 126),1,8) + '01' AS DATE) as DataConsulta
From Agendas
Where CpfProfissional = @cpfProfissional
Group by  CAST(substring(CONVERT(nvarchar(30), DataAgenda, 126),1,8) + '01' AS DATE)
Order by DataConsulta
