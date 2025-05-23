var $j = jQuery.noConflict();
$j(document).ready(function(){
	var InitMask = function () {
		$j('#RadTextBox_ID_CR').mask('9999999999', {reverse: true});
		$j('#DatePicker_DATA_CR_dateInput').mask('99/99/9999', {reverse: true});
		$j('#RadTextBox_ID_VENDA').mask('9999999999', {reverse: true});
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
