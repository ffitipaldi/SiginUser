
-----------------------------------------------------
-- atualiza a FlagCandidatoCompareceu no Id da Agenda
-----------------------------------------------------

Declare @id integer
declare @flg bit

set @id = 1
set @flg = 0

update Agendas
set FlagCandidatoCompareceu = @flg
where Id = @id