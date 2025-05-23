var $j = jQuery.noConflict();
$j(document).ready(function(){
	var InitMask = function () {
		$j('#RadTextBox_TOTAL_VENDA').mask('99999999,99', {reverse: true});
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
