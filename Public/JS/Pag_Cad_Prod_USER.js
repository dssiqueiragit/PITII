var $j = jQuery.noConflict();
$j(document).ready(function(){
	var InitMask = function () {
		$j('#RadTextBox_NOME_PRODUTO').mask('M', {
			onKeyPress: function (value, event) {
				event.currentTarget.value = value.toUpperCase();
			}
		});
		$j('#RadTextBox_VALOR_PRODUTO').mask('99.999.999,99', {reverse: true});
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
