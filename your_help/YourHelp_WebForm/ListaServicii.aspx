<%@ Page Title="Servicii" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPersoane.aspx.cs" Inherits="YourHelp_WebForm.ListaServicii" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="productList" runat="server" 
                DataKeyNames="id_serviciu" GroupItemCount="4"
                ItemType="LibrarieModele.Serviciu" SelectMethod="GetServicii">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>Nu a fost gasita nici un serviciu.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <span>
                                        <b> Nume: </b><%#:Item.nume_serviciu%>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>
                                         <b>Descriere: </b> <%#:Item.descriere%>
                                    </span>
                                    <br />
                                    <span>
                                        <b>Categorie: </b><%#:Item.categorie.nume_categorie%>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
