--Seleciona uma lista de resumo de agendas por data de agendas

DECLARE @cpfProfissional as nvarchar(11) = '19346827807'
DECLARE @dataDE as nvarchar(10) = '2022-05-30'
DECLARE @dataATE as nvarchar(10) = '2022-08-30'

Select  Id, 
		HoraAgenda, 
		NomeCandidato, 
		Telefone,
		StatusExPsico,
		FlagCandidatoCompareceu
From Agendas
Where CpfProfissional = @cpfProfissional
  AND CAST(DataAgenda AS DATE) BETWEEN CAST(@dataDE as DATE) AND CAST(@dataATE as DATE)
Order by DataAgenda


