namespace ViewModelProvider.Data
{
    /// <summary>
    /// Products and Services Data Model
    /// </summary>
    public class ProductAndService
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string LocationCode { get; set; }

        /// <summary>
        /// Gets or sets the location name.
        /// </summary>
        /// <value>
        /// The location name.
        /// </value>
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the Product Group.
        /// </summary>
        /// <value>
        /// The Product Group.
        /// </value>
        public string GroupCode { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        /// <value>
        /// The name of product group.
        /// </value>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The product or service code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The product or description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the supplier1.
        /// </summary>
        /// <value>
        /// The supplier1.
        /// </value>
        public string Supplier1 { get; set; }

        /// <summary>
        /// Gets or sets the supplier2.
        /// </summary>
        /// <value>
        /// The supplier2.
        /// </value>
        public string Supplier2 { get; set; }

        /// <summary>
        /// Gets or sets the supplier3.
        /// </summary>
        /// <value>
        /// The supplier3.
        /// </value>
        public string Supplier3 { get; set; }

        /// <summary>
        /// Gets or sets the ServiceItem character.
        /// </summary>
        /// <value>
        /// The ServiceItem character.
        /// </value>
        public string ServiceItem { get; set; }

        /// <summary>
        /// Gets or sets Quantity in Stock.
        /// </summary>
        /// <value>
        /// The Quantity in Stock.
        /// </value>
        public double QtyInStock { get; set; }

        /// <summary>
        /// Gets or sets Quantity in Order.
        /// </summary>
        /// <value>
        /// The Quantity in Order.
        /// </value>
        public double QtyOrder { get; set; }

        /// <summary>
        /// Gets or sets Quantity in BackOrder.
        /// </summary>
        /// <value>
        /// The Quantity in BackOrder.
        /// </value>
        public double QtyBackOrder { get; set; }

        /// <summary>
        /// Gets or sets Quantity Reserved.
        /// </summary>
        /// <value>
        /// The Quantity Reserved.
        /// </value>
        public double QtyReserved { get; set; }

        /// <summary>
        /// Gets or sets Quantity Consigned.
        /// </summary>
        /// <value>
        /// The Quantity Consigned.
        /// </value>
        public double QtyConsigned { get; set; }

        /// <summary>
        /// Gets or sets Quantity Requisitioned.
        /// </summary>
        /// <value>
        /// The Quantity Requisitioned.
        /// </value>
        public double QtyRequisitioned { get; set; }

        /// <summary>
        /// Gets or sets Quantity PurchaseOrder.
        /// </summary>
        /// <value>
        /// The Quantity PurchaseOrder.
        /// </value>
        public double QtyPurchaseOrder { get; set; }

        /// <summary>
        /// Gets or sets BOM Quantity Reserved.
        /// </summary>
        /// <value>
        /// BOM Quantity Reserved.
        /// </value>
        public double BOMQtyReserved { get; set; }

        /// <summary>
        /// Gets or sets BOM Quantity Production Batch.
        /// </summary>
        /// <value>
        /// BOM Quantity Production Batch.
        /// </value>
        public double BOMQtyProductionBatch { get; set; }

        /// <summary>
        /// Gets or sets Unit Cost.
        /// </summary>
        /// <value>
        /// The Unit Cost.
        /// </value>
        public double UnitCost { get; set; }

        /// <summary>
        /// Gets or sets Stock Unit.
        /// </summary>
        /// <value>
        /// The Stock Unit.
        /// </value>
        public string StockUnit { get; set; }

        /// <summary>
        /// Gets or sets Purchase Unit.
        /// </summary>
        /// <value>
        /// The Purchase Unit.
        /// </value>
        public string PurchaseUnit { get; set; }

        /// <summary>
        /// Gets or sets the Purchase Conversion.
        /// </summary>
        /// <value>
        /// The Purchase Conversion.
        /// </value>
        public double PurchaseConversion { get; set; }

        /// <summary>
        /// Gets or sets the Field containing the Status Flags.
        /// </summary>
        /// <value>
        /// Integer containing the Status Flags.
        /// </value>
        public int StatusFlags { get; set; }

        /// <summary>
        /// Gets or sets the include in sales reporting.
        /// </summary>
        /// <value>
        /// The include in sales reporting.
        /// </value>
        public char IncludeInSalesReporting { get; set; }

        /// <summary>
        /// Gets or sets the reorder level.
        /// </summary>
        /// <value>
        /// The reorder level.
        /// </value>
        public double ReorderLevel { get; set; }

        /// <summary>
        /// Gets or sets the reorder qty.
        /// </summary>
        /// <value>
        /// The reorder qty.
        /// </value>
        public double ReorderQty { get; set; }

        /// <summary>
        /// Gets or sets the barcode.
        /// </summary>
        /// <value>
        /// The barcode.
        /// </value>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the type of the BOM product.
        /// </summary>
        /// <value>
        /// The type of the BOM product.
        /// </value>
        public string BomProductType { get; set; }

        /// <summary>
        /// Gets or sets the manufacture quantity.
        /// </summary>
        /// <value>
        /// The manufacture quantity.
        /// </value>
        public double ManufactureQuantity { get; set; }

        /// <summary>
        /// Gets or sets the gl set.
        /// </summary>
        /// <value>
        /// The gl set.
        /// </value>
        public string GLSet { get; set; }
    }
}