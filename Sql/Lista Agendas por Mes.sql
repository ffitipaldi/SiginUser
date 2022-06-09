--Seleciona uma lista de resumo de agendas por mes de agendas

DECLARE @cpfProfissional as nvarchar(11) = '19346827807'
DECLARE @dataMes as nvarchar(10) = '2022-06-01'

Select  ag.Id,
		ag.DataAgenda,
		ag.HoraAgenda, 
		ag.NomeCandidato, 
		ag.Telefone,
		dm.Descricao as TipoProcesso,
		ag.StatusExPsico
From Agendas as ag
Inner Join Dominios as dm ON dm.Campo = 'TipoProcesso'
Where ag.CpfProfissional = @cpfProfissional
  AND substring(CONVERT(nvarchar(30), ag.DataAgenda, 126),1,8) + '01' = @dataMes
  AND dm.Sigla = ag.TipoProcesso
Order by ag.DataAgenda

