var checkout = {
    init: function () {
        checkout.countryChange();
        checkout.payment();
        checkout.infoChange();
    },

    countryChange: function () {
        $("select.country_api").change(function () {
            var Id = $(this).children("option:selected").data('id')
            $.ajax({
                url: '/CountryApi/GetProvinces',
                data: { Id: Id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        let html = ''
                        response.provinces.forEach(p => {
                            html += ` <option value="${p.Name}" data-id="${p.Id}">${p.Name}</option>`
                        })

                        $('.province_api').html(html)
                    }
                }
            });
        });

        $("select.province_api").change(function () {
            var Id = $(this).children("option:selected").data('id')
            $.ajax({
                url: '/CountryApi/GetDistricts',
                data: { Id: Id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        let html = ''
                        response.districts.forEach(p => {
                            html += ` <option value="${p.Name}" data-id="${p.Id}">${p.Name}</option>`
                        })

                        $('.district_api').html(html)
                    }
                }
            });
        });

        $("select.district_api").change(function () {
            var Id = $(this).children("option:selected").data('id')
            $.ajax({
                url: '/CountryApi/GetWards',
                data: { Id: Id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        let html = ''
                        response.wards.forEach(p => {
                            html += ` <option value="${p.Name}" data-id="${p.Id}">${p.Name}</option>`
                        })

                        $('.ward_api').html(html)
                    }
                }
            });
        });
    },

    payment: function () {
        $('.button-paypal').click(function (e) {
            var b = 1
            if ($('.checkbox_privacy').is(":checked") == false) {
                $('.div_checkbox_privacy').css('border-style', 'solid')
                b = 0
            }
            if ($('.checkbox_checkpay').is(":checked") == false
                && $('.checkbox_paypal').is(":checked") == false) {
                $('.div_pay_method').css('border-style', 'solid')
                b = 0
            }

            if ($.trim($('.first-name').val()) == "") {
                $('.first-name').css('border-style', 'solid')
                $('.first-name').css('border-color', 'orangered')
                b = 0
            }
            if ($.trim($('.last-name').val()) == "") {
                $('.last-name').css('border-style', 'solid')
                $('.last-name').css('border-color', 'orangered')
                b = 0
            }
            if ($.trim($('.phone-number').val()) == "") {
                $('.phone-number').css('border-style', 'solid')
                $('.phone-number').css('border-color', 'orangered')
                b = 0
            }
            if ($.trim($('.email-address').val()) == "") {
                $('.email-address').css('border-style', 'solid')
                $('.email-address').css('border-color', 'orangered')
                b = 0
            }

            $.ajax({
                url: '/Login/IsLogin',
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        document.getElementById('contact_form').submit()
                    }
                },
            });

            if (b == 1) {
                document.getElementById('contact_form').submit()
            }
        })
    },

    infoChange: function () {
        $('.checkbox_privacy').change(function (e) {
            if ($(this).is(":checked")) {
                $('.div_checkbox_privacy').css('border-style', 'none')
            }
        })
        $('.checkbox_checkpay').change(function (e) {
            if ($(this).is(":checked")) {
                $('.div_pay_method').css('border-style', 'none')
                $('.checkbox_paypal').prop('checked', false)
                var pay = $('.paymentMethod')
                pay.removeData()
                pay.val('1')
            }
        })
        $('.checkbox_paypal').change(function (e) {
            if ($(this).is(":checked")) {
                $('.div_pay_method').css('border-style', 'none')
                $('.checkbox_checkpay').prop('checked', false)
                var pay = $('.paymentMethod')
                pay.removeData()
                pay.val('2')
            }
        })
        $('.checkbox_paypal').change(function (e) {
            if ($(this).is(":checked")) {
                $('.div_pay_method').css('border-style', 'none')
                $('.checkbox_checkpay').prop('checked', false)
            }
        })
        $('.first-name').change(function (e) {
            if ($(this).val().trim() != "") {
                $(this).css('border-color', '#ced4da')
            }
        })
        $('.last-name').change(function (e) {
            if ($(this).val().trim() != "") {
                $(this).css('border-color', '#ced4da')
            }
        })
        $('.phone-number').change(function (e) {
            if ($(this).val().trim() != "") {
                $(this).css('border-color', '#ced4da')
            }
        })
        $('.email-address').change(function (e) {
            if ($(this).val().trim() != "") {
                $(this).css('border-color', '#ced4da')
            }
        })
    },
};
checkout.init();







