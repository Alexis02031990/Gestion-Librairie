function PrintBill() {
    var PGrid = document.getElementById('<%=BillList.ClientID%>');
    PGrid.bordr = 0;
    var PWin = window.open('', 'PrintGrid', 'left=100,top=100,width=1024,height=768,tollbar = 0,scrollbars = 1, status = 0,resizable = 1');
    PWin.document.write(PGrid.outerHTML);
    PWin.document.close;
    PWin.focus();
    PWin.print();
    PWin.close();
}