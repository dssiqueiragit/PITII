var $j = jQuery.noConflict();
$j(document).ready(function(){
	var InitMask = function () {
		$j('#RadTextBox_TOTAL_VENDA').mask('99999999,99', {reverse: true});
		$j('.GridColumn_ID_PRODUTO').mask('9999999999', {reverse: true});
		$j('.GridColumn_QTDE_VENDA_ITEM').mask('9999999999', {reverse: true});
		$j('.GridColumn_VALOR_VENDA_ITEM').mask('99999999,99', {reverse: true});
		$j('.GridColumn2').mask('999.999,00', {reverse: true});
		$j('#RadTextBox1').mask('9999999999', {reverse: true});
	};
	InitMask();
	var prm = Sys.WebForms.PageRequestManager.getInstance();
	if (prm != null) {
		prm.add_endRequest(function (sender, e) {
			if (sender._postBackSettings.panelsToUpdate != null) {
				InitMask();
			}
		});
	};
 });
