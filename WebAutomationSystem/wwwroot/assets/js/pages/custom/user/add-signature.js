"use strict";

// Class Definition
var KTAddSignature = function () {
	// Private Variables
	var _wizardEl;
	var _formEl;
	var _wizard;
	var _signature;

	// Private Functions
	var _initWizard = function () {
		// Initialize form wizard
		_wizard = new KTWizard(_wizardEl, {
			startStep: 1, // initial active step number
			clickableSteps: true  // allow step clicking
		});

		// Change Event
		_wizard.on('change', function (wizard) {
			KTUtil.scrollTop();
		});
	}

	var _initSignature = function () {
		_signature = new KTImageInput('kt_user_add_signature');
	}

	return {
		// public functions
		init: function () {
			_wizardEl = KTUtil.getById('kt_wizard');
			_formEl = KTUtil.getById('kt_form');

			_initWizard();
			_initSignature();
		}
	};
}();

jQuery(document).ready(function () {
    KTAddSignature.init();
});
