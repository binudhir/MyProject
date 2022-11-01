CREATE TRIGGER pret_del_item ON pret2
AFTER DELETE AS DECLARE @itcd BIGINT, @recstk MONEY, @prdtp INT
SELECT @itcd = it_cd, @recstk = pret_qty, @prdtp = prd_tp FROM deleted
BEGIN
 IF @prdtp = 1
  BEGIN
   UPDATE item SET rec_stk = rec_stk + @recstk, cl_stk = cl_stk + @recstk WHERE it_cd= @itcd
  END
 ELSE
  BEGIN
   UPDATE item SET rrec_stk = rrec_stk + @recstk, rcl_stk = rcl_stk + @recstk WHERE it_cd = @itcd
  END
END