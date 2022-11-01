CREATE TRIGGER purch_ins_item ON purch2
AFTER INSERT AS DECLARE @itcd BIGINT, @recstk MONEY, @frqty MONEY, @prdtp INT, @posl BIGINT
SELECT @itcd = it_cd, @recstk = pur_qty, @frqty = free_qty, @prdtp = prd_tp, @posl = po_sl FROM inserted
BEGIN
 IF @posl = 0
  BEGIN
   IF  @prdtp = 1
    BEGIN
      UPDATE item SET rec_stk = rec_stk + @recstk, cl_stk = cl_stk + @recstk WHERE it_cd= @itcd
    END
  ELSE
    BEGIN
     UPDATE item SET rrec_stk = rrec_stk + @recstk, rcl_stk = rcl_stk + @recstk WHERE it_cd = @itcd
    END
  END
    ELSE
     BEGIN
      UPDATE porder2 SET bpo_qty = bpo_qty + @recstk, bpo_free = bpo_free + @frqty, billed = 'Y' WHERE po_sl = @posl
     END
END 