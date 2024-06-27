using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caregory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caregory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Caregory_Category",
                        column: x => x.Category,
                        principalTable: "Caregory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Product_Product",
                        column: x => x.Product,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sale_Sale",
                        column: x => x.Sale,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Caregory",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electrodomésticos" },
                    { 2, "Tecnología y Electrónica" },
                    { 3, "Moda y Accesorios" },
                    { 4, "Hogar y Decoración" },
                    { 5, "Salud y Belleza" },
                    { 6, "Deportes y Ocio" },
                    { 7, "Juguetes y Juegos" },
                    { 8, "Alimentos y Bebidas" },
                    { 9, "Libros y Material Educativo" },
                    { 10, "Jardinería y Bricolaje" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Category", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0860ff93-91a5-4522-b52f-88c31f0edf62"), 10, "Con la Motosierra Philco podés hacer cortes profesionales de todo tipo de maderas, para podar, cortar árboles y hacer numerosos trabajos de jardinería. Es tu aliada perfecta para superar cualquier obstáculo. Con su diseño ergonómico y potente motor, te brinda la confianza y el control necesarios para realizar trabajos eficientes y precisos", 0, "https://live.staticflickr.com/65535/53719067988_7233dcb4d5_c.jpg", "Motosierra Philco A Nafta Espada 45 Cm 52cc ", 199.999m },
                    { new Guid("0a221762-491d-44b8-b895-4588cb16d55e"), 7, "Incluye 70 piezas, 2 muñecos, 15 stickers, guía de armado, edad recomendada 5 años, juguete no tóxico, fabricado sin ftalatos ni colorantes.", 22, "https://live.staticflickr.com/65535/53719293110_12aff0ecb7_z.jpg", "Juego De Bloques Blocky Bomberos", 8.999m },
                    { new Guid("0e6375b6-ec58-4f0e-a5c3-39a23bd0afbe"), 4, "Diseño pensado a detalle para que desbloquees el siguiente nivel de confort en tu lugar reservado para jugar hasta que en la pantalla de tu adversario aparezca game over.", 0, "https://live.staticflickr.com/65535/53719027875_ce71b5ae27_b.jpg", "Escritorio Gamer PC 2M", 217.14m },
                    { new Guid("0f953a21-3593-47cf-a628-ba72f5c075a5"), 5, " Estructura: 80% madera maciza y 20% aglomerado de partículas.Asiento: Cinchas elásticas y placa poliéster soft. Relleno: Guata y copo de poliéster. Costura: Costura reforzada. Patas: Inyección plástica.", 51, "https://live.staticflickr.com/65535/53719292920_9be848db03_b.jpg", "Masajeador Facial Anti Arrugas y Ojeras", 29.999m },
                    { new Guid("32926202-3b02-4f67-a8b4-70316da53724"), 5, "Es una crema de una avanzada tecnología que no es grasosa y brinda una mayor potencia de humectación para pieles o zonas con mayor resequedad o sensibles", 20, "https://live.staticflickr.com/65535/53719197089_e5897ffef8_b.jpg", "Crema Hidratante Piel Extra Seca Y Sensible Cetaphil ", 29.19m },
                    { new Guid("343e78d7-5c48-4613-8390-17bf4d3fdf65"), 7, "Panel LED con teclas luminosas, colorida pantalla, entrada y salida de audio, control deslizante de volumen, efectos scratch, pulsadores para varios efectos, selección de ritmo, altavoz, auriculares.", 29, "https://live.staticflickr.com/65535/53717952902_4fb8a4f480_b.jpg", "Consola Dj Mixer Juguete con Luz y Sonido  ", 56.999m },
                    { new Guid("37bc713f-c843-4337-acf6-81fed6c6e37c"), 3, " Detalles: Plastico, Polarizado, Filtro UV 100%.", 0, "https://live.staticflickr.com/65535/53717952727_0beeb2eb96_c.jpg", "Anteojos Vulk Evan C14 Hombre", 27.199m },
                    { new Guid("3e8851b7-e40d-4fec-bb60-b74edb81092d"), 6, "Este casco puede usarse para adultos, es talle L con un calce cómodo y regulable.", 0, "https://live.staticflickr.com/65535/53719068238_0e3faa89b6_b.jpg", "Casco Bicicleta Raleigh 29vent.", 48.889m },
                    { new Guid("3f868c70-d7df-4d17-b7e4-f427ba01c91d"), 8, "Paquete en versión de 500g, Porotos alubias, puede contener soja", 0, "https://live.staticflickr.com/65535/53719068053_43f1ef3725_c.jpg", "Porotos Mister Food Alubia", 550m },
                    { new Guid("46eb1daf-4367-43a5-972a-f6e1041712b1"), 1, "La heladera cíclica Drean cuenta con un diseño clásico tipo Top Mount, es decir que ubica el freezer en la parte superior y en la parte inferior el refrigerador…", 28, "https://live.staticflickr.com/65535/53719197674_a49611799a_h.jpg", "Heladera Cíclica Drean 277Lts", 815.799m },
                    { new Guid("47b3b7f0-3a07-4c0d-9be9-306030972506"), 4, "Estructura: 80% madera maciza y 20% aglomerado de partículas.Asiento: Cinchas elásticas y placa poliéster soft. Relleno: Guata y copo de poliéster. Costura: Costura reforzada. Patas: Inyección plástica.", 39, "https://live.staticflickr.com/65535/53718859006_e08de196f9_b.jpg", "Sillón Esquinero Gris Piazza Chaise Longue G3", 985m },
                    { new Guid("4a82ab25-f739-4af8-9733-7a24cea6f909"), 9, "Explora la evolución de los videojuegos desde sus orígenes en el MIT hasta su posición actual como fenómeno mundial. Analiza la influencia de los arcades en la popularización del medio, el legado de Mario y su impacto en la cultura pop, y el éxito de Pokémon como estrategia de mercadeo basada en la nostalgia.", 0, "https://live.staticflickr.com/65535/53718804473_3470e0fddc_z.jpg", "FENOMENOS GAMERS, de Nicolas Rabago", 19.6m },
                    { new Guid("4d550063-dcb4-442e-b691-c115942eaa5f"), 2, "Mediante su entrada PC In podrás conectar tu PC o Notebook. Además, también ofrece la posibilidad de conectarse a través de HDMI. El LED no tiene sistema de audio incorporado… ", 0, "https://live.staticflickr.com/65535/53717962502_433fcae179.jpg", "Monitor Gamer Samsung 27”", 299.999m },
                    { new Guid("5046a370-6f64-46d0-94b5-70239392029e"), 3, "Billetera de la marca Billabong, confeccionada con Cuero sintético, con monedero y porta tarjetas interior.", 0, "https://live.staticflickr.com/65535/53719292905_3fc4010ea3_z.jpg", "Billetera Billabong Dimension M Wllt Hombre", 29.999m },
                    { new Guid("531e7b59-e5a1-4995-9a0b-922c8376a0f6"), 7, "Monopoly Classic es un juego de mesa divertido y emocionante que es perfecto para familias y amigos. Es un juego de estrategia, negociación y suerte, y siempre hay algo nuevo que aprender.", 29, "https://live.staticflickr.com/65535/53719068198_262dc4d39d_b.jpg", "Juego de Mesa Monopoly Clásico", 99.99m },
                    { new Guid("6785b0aa-3b55-44aa-a3f2-c4b5cabdc71c"), 1, "La Escorial Candor S2 es una cocina de diseño clásico en color negro que cuenta con cuatro hornallas; horno y cajón parrilla independiente…", 9, "https://live.staticflickr.com/65535/53719068348_b7c689988e_b.jpg", "Cocina Escorial Candor S2 Gas Natural", 273.099m },
                    { new Guid("6fee0b2b-58f6-4908-a00f-3815a7aa090d"), 9, "Editorial: Oberon, páginas: 336, idioma Español. Clasificación Ingenieria, Tecnica Y Ciencias Exactas - Otras Ciencias Exactas - Astronomia", 0, "https://live.staticflickr.com/65535/53719027845_afa4363a12_c.jpg", "Vida En Marte - David A. Weintraub", 23.56m },
                    { new Guid("7b1e02ff-4089-4305-bab1-2aa1dff20865"), 6, "Una bicicleta fija, equipada con un volante de inercia resistente, puede proporcionar Más potencia y te ofrece una experiencia deportiva desafiante", 0, "https://live.staticflickr.com/65535/53717953012_86ed80f952_b.jpg", "Bicicleta Fija Para Spinning Tm Acero", 272.599m },
                    { new Guid("7b2b20ef-13a7-42c0-af36-a5e600c4179e"), 5, "Remueve impurezas de la piel, efecto antiarrugas y antiojeras, reduce las arrugas de ojos y ojeras, promueve la absorción de la crema para la piel, alivia la fatiga de los ojos, 2 velocidades de vibración, funciona con pila CR2032 (incluida).", 35, "https://live.staticflickr.com/65535/53717953097_d396fbc284_z.jpg", "Balanza De Vidrio Para Baño Beurer Gs-10 ", 31.04m },
                    { new Guid("7cdf4661-18cf-4fd6-9769-4e2febbc9a43"), 3, ":Una riñonera con estilo universitario, hecha parcialmente con materiales reciclados Más que una marca de nuestro legado, el monograma del Trifolio de esta canguro adidas es una declaración sutil que hace que cada outfit sea más prémium.", 10, "https://live.staticflickr.com/65535/53718858981_4242bb338f_z.jpg", "Riñonera adidas Wb L Trefoil Aop", 58.999m },
                    { new Guid("876e47a4-e79c-4d79-b3f9-22dae6902efc"), 2, "La notebook lenovo IDEAPAD 1 es exactamente lo que necesita una computadora portátil de uso diario. Vea programas en una pantalla HD de hasta 14 pulgadas con un marco extremadamente delgado.", 39, "https://live.staticflickr.com/65535/53719293375_9d5bf7ecfc_c.jpg", "Notebook Lenovo Ideapad 1", 599.999m },
                    { new Guid("94800096-6358-4513-9b62-acc39b2e9210"), 6, "Este casco puede usarse tanto en jóvenes como adultos ya que es regulable de los 57CM a los 62CM. Es muy fácil de trasladar ya que es muy liviano y cómodo a la hora de usar y hacer viajes largos.", 23, "https://live.staticflickr.com/65535/53719197584_7fe947d387_b.jpg", "Casco Bicicleta Zykel Con Visera", 27.624m },
                    { new Guid("99ccad59-0e30-40d6-8448-7883ca9707f6"), 4, "Botón táctil » Luz: 3000 K - 6000 K » 120 LED por metro (1360 lúmenes) » Función antiempañe » Función lupa (x5) » Reloj, fecha, temperatura » Alimentación 220 V » Transformador 12 V", 0, "https://live.staticflickr.com/65535/53718595071_264a110f2f_b.jpg", "Espejos Grandes Redondo Pared Con Luz Led Moderno Tactil", 383.613m },
                    { new Guid("9a78776d-a4ef-4889-99e1-c0532bd36765"), 8, "Agua carbonatada, azúcar, colorante, aromas (contiene cafeína), acidulante y edulcorantes. No contiene alérgenos de obligada declaración. Mejor que bueno.", 0, "https://live.staticflickr.com/65535/53718859141_4f7509983e_c.jpg", "Gaseosa Pepsi Botella 2lt", 2.4m },
                    { new Guid("a4bad3c1-d33c-4e46-b988-6444f5f57106"), 1, "La cocina electrolux 56DXQ cuenta con 2 hornos independientes, uno eléctrico y uno a gas, permitiendo que se puedan realizar preparaciones simultáneamente y con excelente calidad…", 10, "https://live.staticflickr.com/65535/53718859411_2aaff35ca1_b.jpg", "Cocina Electrolux 56DXQ ", 999.999m },
                    { new Guid("a719f896-2560-485c-87be-488eb26668b1"), 4, "Con indicadores de confort, incluso pequeños cambios de temperatura, control de humedad en un vistazo. Supervisión continua de los cambios de temperatura y humedad en el interior. Atención y apoyo durante todo el año para la salud de su familia", 50, "https://live.staticflickr.com/65535/53719067948_9c9a19588d_b.jpg", "Reloj monitor de temperatura y humedad Xiaomi", 126.789m },
                    { new Guid("a9ff78be-ba15-41dd-aee3-05c236cc9df6"), 7, "Incluye 70 piezas, 2 muñecos, 15 stickers, guía de armado, edad recomendada 5 años, juguete no tóxico, fabricado sin ftalatos ni colorantes.", 0, "https://live.staticflickr.com/65535/53719293070_40e76c28a2_b.jpg", "Juego De Bloques Blocky Policías", 8.999m },
                    { new Guid("ab8adb43-3efd-4df8-91cc-6e351b332ee9"), 8, "Nada supera el sabor de una Coca-Cola. Diseñado para acompañar cada momento, el sabor de la Coca-Cola es un clásico que perdura desde hace más de 130 años. Deliciosa y refrescante.", 0, "https://live.staticflickr.com/65535/53718859136_a1630f9d0e_c.jpg", "Gaseosa Coca-cola Sabor Original 2.25 L", 2.175m },
                    { new Guid("abf6ad44-a85e-4b94-809e-2b8ce64381be"), 10, "Con su potencia de 105 bar podés dejar reluciente cualquier material o superficie. Su impacto de agua a alta presión es entre diez y cincuenta veces más potente que las mangueras de jardín, lo que hace más eficaz y fácil el proceso de limpieza.", 33, "https://live.staticflickr.com/65535/53719197264_aba2f039b4_c.jpg", "Hidrolavadora Daewoo 1200 Watts 105 Bar con Autostop", 149.999m },
                    { new Guid("acf4d5dc-d3f2-4e80-a096-82b54e5bfc31"), 3, "Detalles: Acetato, Polarizado, Calibre 49, Filtro UV 100%.", 10, "https://live.staticflickr.com/65535/53719197069_e71be01f4c_c.jpg", "Anteojos Vulk Rolling Stones I Can T", 172.299m },
                    { new Guid("b7e0ec4c-c5e9-4ebb-870d-466d343f8fef"), 2, "Cuenta con una excelente pantalla de 27” pulgadas y resolución FHD (1920x1080) para que disfrutes de ver todo tu contenido en gran calidad.", 15, "https://live.staticflickr.com/65535/53718858866_667f299812_z.jpg", "Monitor Noblex 27” FHD", 329.999m },
                    { new Guid("c0596004-6c98-42a2-9f7e-3d27864afbce"), 10, "La cortadora de cesped eléctrica DAC1600 de Daewoo cuenta con una potencia de 1600 watts , mientras que, el voltaje es de 220/50 Hz. A su vez posee una manija ergonómica para una mayor comodidad del usuario, es plegable y pertenece a la línea ECO. ", 42, "https://live.staticflickr.com/65535/53717952837_e7c9735857_b.jpg", "Cortadora de césped Daewoo Eléctrica ", 349.999m },
                    { new Guid("c4f9aafe-690c-4a2c-b744-7a76af829f6f"), 6, "Cinta motorizada para caminar y correr. Su consola LED posee un diseño moderno con luz blanca y 4 ventanas que permiten monitorear velocidad, tiempo, distancia y calorías consumidas.", 25, "https://live.staticflickr.com/65535/53717952967_7bffd436ef_b.jpg", "Cinta Motorizada Randers ARG-472 ", 999.999m },
                    { new Guid("d4cf3248-ce7f-42bf-afff-d8f6e32cf144"), 2, "Descubrí la excepcional ligereza y delgadez de este portátil, convirtiéndolo en un equipo versátil y fácil de llevar a todas partes. Su pantalla Full HD de 15.6 pulgadas no solo proporciona comodidad para trabajar, sino que también garantiza una calidad de imagen excepcional.", 0, "https://live.staticflickr.com/65535/53718858836_d9b3356be0_b.jpg", "Notebook HP 15 Core i3 8GB", 879.999m },
                    { new Guid("d61e32be-ccbb-4b2c-bd10-1fe30dcc87f1"), 5, "adnic presenta su nueva linea de Mascara Led ! Esta mascara es ideal para el cuidado de la piel y combatir el acné. Gracias a su gran pantalla táctil hace que sea muy fácil a la hora de usar. Cuenta con 192 luces LED y 7 diferentes colores. Dependiendo del tipo de luz elegida se pueden realizar diferentes tratamientos.", 0, "https://live.staticflickr.com/65535/53719293380_91591160b3_b.jpg", "Mascara Facial Led Gadnic LT3.0 Terapia Acné Rejuvenecimiento", 77.999m },
                    { new Guid("e3d3adbd-6af2-4ccc-a2da-5735461afdb3"), 9, "Que son las contraseñas? ?Como se construyen? ?En que momento de la historia surgieron? Estas son solo algunas de las preguntas que sirven como disparador para que Martin Paul Eve despliegue su conocimiento sobre las implicancias y el funcionamiento de las contraseñas", 0, "https://live.staticflickr.com/65535/53718804428_46d29bccb5_z.jpg", "Una Historia De Las Contr45eñ4s - Martin Paul Eve ", 17.999m },
                    { new Guid("e52c2baf-0e01-4b80-9727-b0b18087e9e9"), 8, "Quínoa, zanahoria deshidratada, cebolla deshidratada, morrón deshidratado, espinaca deshidratada, perejil deshidratado, sal, azúcar, pimentón dulce, nuez moscada, coriandro, pimienta blanca.", 0, "https://live.staticflickr.com/65535/53719197404_d08d446ac1_c.jpg", "Quinoa Con Vegetales Y Champignones", 5.85m },
                    { new Guid("ea61c896-0222-41f1-97d4-8abe1b6a1662"), 9, "Editorial: RBA Bolsillo, páginas: 160, idioma Español. Clasificación Ingenieria, Tecnica Y Ciencias Exactas - Ingenieria - General", 0, "https://live.staticflickr.com/65535/53718804433_acc579be06_b.jpg", "Inteligencia Artificial (bolsillo) - Ignasi Belda Reig", 15.9m },
                    { new Guid("ebdf976c-82a1-4d60-aeca-7d593f3ec732"), 10, " La bordeadora de césped severbon cuenta con motor eléctrico y una potencia de 1000 watts. Posee una manija ajustable en altura, que te brindará una mayor comodidad y te facilitará su uso.", 40, "https://live.staticflickr.com/65535/53718858996_1826022f50_b.jpg", "Bordeadora Eléctrica Severbon", 99.999m },
                    { new Guid("fe2c0b9c-3c84-4aa5-9e45-a63501199fe7"), 1, "La heladera Sigma combina su cómodo diseño con una gran utilidad. En su interior, cuenta con un bandejón con tapa y 3 prácticos estantes para que puedas acomodar tus alimentos de la mejor forma…", 0, "https://live.staticflickr.com/65535/53717953172_45f2071196_h.jpg", "Heladera Cíclica Sigma 239Lts", 559.999m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category",
                table: "Product",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Product",
                table: "SaleProduct",
                column: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Sale",
                table: "SaleProduct",
                column: "Sale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Caregory");
        }
    }
}
