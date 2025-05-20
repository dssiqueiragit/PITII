var $j = jQuery.noConflict();
$j(document).ready(function(){
	var InitMask = function () {
		$j('#txtUser').mask('999.999.999-99');
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
