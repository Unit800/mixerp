﻿<%-- 
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
--%>
<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" MasterPageFile="~/MixERPBlankMaster.Master" CodeBehind="PartiesPopup.aspx.cs" Inherits="MixERP.Net.FrontEnd.Inventory.Setup.PartiesPopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <link href="/bundles/stylesheets/parties-popup.min.css" rel="stylesheet" />

    <title>Select Party</title>

    <style type="text/css">
        form {
            background-color: white !important;
        }

        #GridPanel {
            width: 99% !important;
        }

        .container {
            padding:24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

        <div class="container" runat="server" id="container">
            <asp:PlaceHolder ID="ScrudPlaceholder" runat="server" />
        </div>
        <script type="text/javascript">

            $("#first_name_textbox").blur(function () {
                updatePartyName();
            });

            $("#middle_name_textbox").blur(function () {
                updatePartyName();
            });

            $("#last_name_textbox").blur(function () {
                updatePartyName();
            });            


            var updatePartyName = function () {
                var p = "<%= GetPartyNameParameter() %>";

                var firstName = $("#first_name_textbox").val();
                var middleName = $("#middle_name_textbox").val();
                var lastName = $("#last_name_textbox").val();

                var partyName = p.replace("FirstName", firstName);
                partyName = partyName.replace("MiddleName", middleName);
                partyName = partyName.replace("LastName", lastName);

                var partyNameTextBox = $("#party_name_textbox");

                //if (partyNameTextBox.val() == "") {
                partyNameTextBox.val(partyName.trim().replace(/ +(?= )/g, ''));
                //}
            };

            var isInIframe = (window.location != window.parent.location) ? true : false;
        </script>
</asp:Content>
