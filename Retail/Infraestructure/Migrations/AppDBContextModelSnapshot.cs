﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Caregory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Caregory", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Electrodomésticos"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Tecnología y Electrónica"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Moda y Accesorios"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Hogar y Decoración"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Salud y Belleza"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Deportes y Ocio"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Juguetes y Juegos"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "Alimentos y Bebidas"
                        },
                        new
                        {
                            CategoryId = 9,
                            Name = "Libros y Material Educativo"
                        },
                        new
                        {
                            CategoryId = 10,
                            Name = "Jardinería y Bricolaje"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(38,17)");

                    b.HasKey("ProductId");

                    b.HasIndex("Category");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("c511641a-d62a-4d9e-b55b-575c14c1e218"),
                            Category = 1,
                            Description = "La heladera cíclica Drean cuenta con un diseño clásico tipo Top Mount, es decir que ubica el freezer en la parte superior y en la parte inferior el refrigerador…",
                            Discount = 28,
                            ImageUrl = "https://live.staticflickr.com/65535/53719197674_a49611799a_h.jpg",
                            Name = "Heladera Cíclica Drean 277Lts",
                            Price = 815.799m
                        },
                        new
                        {
                            ProductId = new Guid("1e8900c7-8aca-4bbf-9efa-65364b4fc38d"),
                            Category = 1,
                            Description = "La heladera Sigma combina su cómodo diseño con una gran utilidad. En su interior, cuenta con un bandejón con tapa y 3 prácticos estantes para que puedas acomodar tus alimentos de la mejor forma…",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53717953172_45f2071196_h.jpg",
                            Name = "Heladera Cíclica Sigma 239Lts",
                            Price = 559.999m
                        },
                        new
                        {
                            ProductId = new Guid("9857d0a9-fbec-4016-9a10-c00e34c94af6"),
                            Category = 1,
                            Description = "La Escorial Candor S2 es una cocina de diseño clásico en color negro que cuenta con cuatro hornallas; horno y cajón parrilla independiente…",
                            Discount = 9,
                            ImageUrl = "https://live.staticflickr.com/65535/53719068348_b7c689988e_b.jpg",
                            Name = "Cocina Escorial Candor S2 Gas Natural",
                            Price = 273.099m
                        },
                        new
                        {
                            ProductId = new Guid("e55f6a1b-31f1-436c-95a5-4735f9c43192"),
                            Category = 1,
                            Description = "La cocina electrolux 56DXQ cuenta con 2 hornos independientes, uno eléctrico y uno a gas, permitiendo que se puedan realizar preparaciones simultáneamente y con excelente calidad…",
                            Discount = 10,
                            ImageUrl = "https://live.staticflickr.com/65535/53718859411_2aaff35ca1_b.jpg",
                            Name = "Cocina Electrolux 56DXQ ",
                            Price = 999.999m
                        },
                        new
                        {
                            ProductId = new Guid("e32014c0-4300-4fe7-923d-840260e48700"),
                            Category = 2,
                            Description = "Mediante su entrada PC In podrás conectar tu PC o Notebook. Además, también ofrece la posibilidad de conectarse a través de HDMI. El LED no tiene sistema de audio incorporado… ",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53717962502_433fcae179.jpg",
                            Name = "Monitor Gamer Samsung 27”",
                            Price = 299.999m
                        },
                        new
                        {
                            ProductId = new Guid("1be48768-9346-4ffa-b3ea-c545d528fccd"),
                            Category = 2,
                            Description = "Cuenta con una excelente pantalla de 27” pulgadas y resolución FHD (1920x1080) para que disfrutes de ver todo tu contenido en gran calidad.",
                            Discount = 15,
                            ImageUrl = "https://live.staticflickr.com/65535/53718858866_667f299812_z.jpg",
                            Name = "Monitor Noblex 27” FHD",
                            Price = 329.999m
                        },
                        new
                        {
                            ProductId = new Guid("27e3f85b-541c-4c12-ab5d-f2b7061d6f86"),
                            Category = 2,
                            Description = "La notebook lenovo IDEAPAD 1 es exactamente lo que necesita una computadora portátil de uso diario. Vea programas en una pantalla HD de hasta 14 pulgadas con un marco extremadamente delgado.",
                            Discount = 39,
                            ImageUrl = "https://live.staticflickr.com/65535/53719293375_9d5bf7ecfc_c.jpg",
                            Name = "Notebook Lenovo Ideapad 1",
                            Price = 599.999m
                        },
                        new
                        {
                            ProductId = new Guid("ff34fb20-c96a-4a8e-81df-d5991ce6341c"),
                            Category = 2,
                            Description = "Descubrí la excepcional ligereza y delgadez de este portátil, convirtiéndolo en un equipo versátil y fácil de llevar a todas partes. Su pantalla Full HD de 15.6 pulgadas no solo proporciona comodidad para trabajar, sino que también garantiza una calidad de imagen excepcional.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53718858836_d9b3356be0_b.jpg",
                            Name = "Notebook HP 15 Core i3 8GB",
                            Price = 879.999m
                        },
                        new
                        {
                            ProductId = new Guid("1656e633-6a07-45d2-a7be-5b912e844c56"),
                            Category = 3,
                            Description = "Detalles: Acetato, Polarizado, Calibre 49, Filtro UV 100%.",
                            Discount = 10,
                            ImageUrl = "https://live.staticflickr.com/65535/53719197069_e71be01f4c_c.jpg",
                            Name = "Anteojos Vulk Rolling Stones I Can T",
                            Price = 172.299m
                        },
                        new
                        {
                            ProductId = new Guid("5db12590-44d9-4453-b1b2-92e674dd4fa4"),
                            Category = 3,
                            Description = " Detalles: Plastico, Polarizado, Filtro UV 100%.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53717952727_0beeb2eb96_c.jpg",
                            Name = "Anteojos Vulk Evan C14 Hombre",
                            Price = 27.199m
                        },
                        new
                        {
                            ProductId = new Guid("9b13ea4e-a09e-4249-85d6-fdfd28db2851"),
                            Category = 3,
                            Description = "Billetera de la marca Billabong, confeccionada con Cuero sintético, con monedero y porta tarjetas interior.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719292905_3fc4010ea3_z.jpg",
                            Name = "Billetera Billabong Dimension M Wllt Hombre",
                            Price = 29.999m
                        },
                        new
                        {
                            ProductId = new Guid("871f0170-0bec-4fa9-9923-1be9b745851b"),
                            Category = 3,
                            Description = ":Una riñonera con estilo universitario, hecha parcialmente con materiales reciclados Más que una marca de nuestro legado, el monograma del Trifolio de esta canguro adidas es una declaración sutil que hace que cada outfit sea más prémium.",
                            Discount = 10,
                            ImageUrl = "https://live.staticflickr.com/65535/53718858981_4242bb338f_z.jpg",
                            Name = "Riñonera adidas Wb L Trefoil Aop",
                            Price = 58.999m
                        },
                        new
                        {
                            ProductId = new Guid("a427ebed-7688-43dd-bb31-59768fac1db5"),
                            Category = 4,
                            Description = "Con indicadores de confort, incluso pequeños cambios de temperatura, control de humedad en un vistazo. Supervisión continua de los cambios de temperatura y humedad en el interior. Atención y apoyo durante todo el año para la salud de su familia",
                            Discount = 50,
                            ImageUrl = "https://live.staticflickr.com/65535/53719067948_9c9a19588d_b.jpg",
                            Name = "Reloj monitor de temperatura y humedad Xiaomi",
                            Price = 126.789m
                        },
                        new
                        {
                            ProductId = new Guid("3bd0f3c7-d041-4c2b-ac39-afd8c1caef6e"),
                            Category = 4,
                            Description = "Estructura: 80% madera maciza y 20% aglomerado de partículas.Asiento: Cinchas elásticas y placa poliéster soft. Relleno: Guata y copo de poliéster. Costura: Costura reforzada. Patas: Inyección plástica.",
                            Discount = 39,
                            ImageUrl = "https://live.staticflickr.com/65535/53718859006_e08de196f9_b.jpg",
                            Name = "Sillón Esquinero Gris Piazza Chaise Longue G3",
                            Price = 985m
                        },
                        new
                        {
                            ProductId = new Guid("82492035-ac21-4326-aaca-51b4830e4b77"),
                            Category = 4,
                            Description = "Botón táctil » Luz: 3000 K - 6000 K » 120 LED por metro (1360 lúmenes) » Función antiempañe » Función lupa (x5) » Reloj, fecha, temperatura » Alimentación 220 V » Transformador 12 V",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53718595071_264a110f2f_b.jpg",
                            Name = "Espejos Grandes Redondo Pared Con Luz Led Moderno Tactil",
                            Price = 383.613m
                        },
                        new
                        {
                            ProductId = new Guid("05d2b87f-d3c0-4076-a435-916f1346733c"),
                            Category = 4,
                            Description = "Diseño pensado a detalle para que desbloquees el siguiente nivel de confort en tu lugar reservado para jugar hasta que en la pantalla de tu adversario aparezca game over.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719027875_ce71b5ae27_b.jpg",
                            Name = "Escritorio Gamer PC 2M",
                            Price = 217.14m
                        },
                        new
                        {
                            ProductId = new Guid("4a18f8ec-47f3-483b-8359-38353811def9"),
                            Category = 5,
                            Description = "Remueve impurezas de la piel, efecto antiarrugas y antiojeras, reduce las arrugas de ojos y ojeras, promueve la absorción de la crema para la piel, alivia la fatiga de los ojos, 2 velocidades de vibración, funciona con pila CR2032 (incluida).",
                            Discount = 35,
                            ImageUrl = "https://live.staticflickr.com/65535/53717953097_d396fbc284_z.jpg",
                            Name = "Balanza De Vidrio Para Baño Beurer Gs-10 ",
                            Price = 31.04m
                        },
                        new
                        {
                            ProductId = new Guid("a3177fb2-0a02-465f-9bb7-8b947b5dd417"),
                            Category = 5,
                            Description = " Estructura: 80% madera maciza y 20% aglomerado de partículas.Asiento: Cinchas elásticas y placa poliéster soft. Relleno: Guata y copo de poliéster. Costura: Costura reforzada. Patas: Inyección plástica.",
                            Discount = 51,
                            ImageUrl = "https://live.staticflickr.com/65535/53719292920_9be848db03_b.jpg",
                            Name = "Masajeador Facial Anti Arrugas y Ojeras",
                            Price = 29.999m
                        },
                        new
                        {
                            ProductId = new Guid("1912b1f3-c201-40ad-8ef6-05c86c3f22e4"),
                            Category = 5,
                            Description = "adnic presenta su nueva linea de Mascara Led ! Esta mascara es ideal para el cuidado de la piel y combatir el acné. Gracias a su gran pantalla táctil hace que sea muy fácil a la hora de usar. Cuenta con 192 luces LED y 7 diferentes colores. Dependiendo del tipo de luz elegida se pueden realizar diferentes tratamientos.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719293380_91591160b3_b.jpg",
                            Name = "Mascara Facial Led Gadnic LT3.0 Terapia Acné Rejuvenecimiento",
                            Price = 77.999m
                        },
                        new
                        {
                            ProductId = new Guid("d94e5712-ad19-4820-a47d-6fb43117338e"),
                            Category = 5,
                            Description = "Es una crema de una avanzada tecnología que no es grasosa y brinda una mayor potencia de humectación para pieles o zonas con mayor resequedad o sensibles",
                            Discount = 20,
                            ImageUrl = "https://live.staticflickr.com/65535/53719197089_e5897ffef8_b.jpg",
                            Name = "Crema Hidratante Piel Extra Seca Y Sensible Cetaphil ",
                            Price = 29.19m
                        },
                        new
                        {
                            ProductId = new Guid("e3705eb2-c1cf-423a-bb0f-552fbd3d2fad"),
                            Category = 6,
                            Description = "Este casco puede usarse tanto en jóvenes como adultos ya que es regulable de los 57CM a los 62CM. Es muy fácil de trasladar ya que es muy liviano y cómodo a la hora de usar y hacer viajes largos.",
                            Discount = 23,
                            ImageUrl = "https://live.staticflickr.com/65535/53719197584_7fe947d387_b.jpg",
                            Name = "Casco Bicicleta Zykel Con Visera",
                            Price = 27.624m
                        },
                        new
                        {
                            ProductId = new Guid("e0ee218f-244a-4bc8-a2a6-6ce4e98bd6e1"),
                            Category = 6,
                            Description = "Este casco puede usarse para adultos, es talle L con un calce cómodo y regulable.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719068238_0e3faa89b6_b.jpg",
                            Name = "Casco Bicicleta Raleigh 29vent.",
                            Price = 48.889m
                        },
                        new
                        {
                            ProductId = new Guid("8f68a00f-2d37-40a0-ab73-e7d0b63f2c87"),
                            Category = 6,
                            Description = "Cinta motorizada para caminar y correr. Su consola LED posee un diseño moderno con luz blanca y 4 ventanas que permiten monitorear velocidad, tiempo, distancia y calorías consumidas.",
                            Discount = 25,
                            ImageUrl = "https://live.staticflickr.com/65535/53717952967_7bffd436ef_b.jpg",
                            Name = "Cinta Motorizada Randers ARG-472 ",
                            Price = 999.999m
                        },
                        new
                        {
                            ProductId = new Guid("3e25fb3e-433b-45dd-9a41-75a956663eb7"),
                            Category = 6,
                            Description = "Una bicicleta fija, equipada con un volante de inercia resistente, puede proporcionar Más potencia y te ofrece una experiencia deportiva desafiante",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53717953012_86ed80f952_b.jpg",
                            Name = "Bicicleta Fija Para Spinning Tm Acero",
                            Price = 272.599m
                        },
                        new
                        {
                            ProductId = new Guid("107b40dc-2331-4cf6-8bec-3235783a7be8"),
                            Category = 7,
                            Description = "Panel LED con teclas luminosas, colorida pantalla, entrada y salida de audio, control deslizante de volumen, efectos scratch, pulsadores para varios efectos, selección de ritmo, altavoz, auriculares.",
                            Discount = 29,
                            ImageUrl = "https://live.staticflickr.com/65535/53717952902_4fb8a4f480_b.jpg",
                            Name = "Consola Dj Mixer Juguete con Luz y Sonido  ",
                            Price = 56.999m
                        },
                        new
                        {
                            ProductId = new Guid("eb05ff39-56e0-4332-8ae0-c67f5fe694e9"),
                            Category = 7,
                            Description = "Incluye 70 piezas, 2 muñecos, 15 stickers, guía de armado, edad recomendada 5 años, juguete no tóxico, fabricado sin ftalatos ni colorantes.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719293070_40e76c28a2_b.jpg",
                            Name = "Juego De Bloques Blocky Policías",
                            Price = 8.999m
                        },
                        new
                        {
                            ProductId = new Guid("eb014fef-1e52-434d-b859-61ea47ecd139"),
                            Category = 7,
                            Description = "Incluye 70 piezas, 2 muñecos, 15 stickers, guía de armado, edad recomendada 5 años, juguete no tóxico, fabricado sin ftalatos ni colorantes.",
                            Discount = 22,
                            ImageUrl = "https://live.staticflickr.com/65535/53719293110_12aff0ecb7_z.jpg",
                            Name = "Juego De Bloques Blocky Bomberos",
                            Price = 8.999m
                        },
                        new
                        {
                            ProductId = new Guid("6296133a-a254-49cf-a0e7-454425913efa"),
                            Category = 7,
                            Description = "Monopoly Classic es un juego de mesa divertido y emocionante que es perfecto para familias y amigos. Es un juego de estrategia, negociación y suerte, y siempre hay algo nuevo que aprender.",
                            Discount = 29,
                            ImageUrl = "https://live.staticflickr.com/65535/53719068198_262dc4d39d_b.jpg",
                            Name = "Juego de Mesa Monopoly Clásico",
                            Price = 99.99m
                        },
                        new
                        {
                            ProductId = new Guid("e0eff592-fb29-46c9-9f47-be0661706718"),
                            Category = 8,
                            Description = "Nada supera el sabor de una Coca-Cola. Diseñado para acompañar cada momento, el sabor de la Coca-Cola es un clásico que perdura desde hace más de 130 años. Deliciosa y refrescante.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53718859136_a1630f9d0e_c.jpg",
                            Name = "Gaseosa Coca-cola Sabor Original 2.25 L",
                            Price = 2.175m
                        },
                        new
                        {
                            ProductId = new Guid("b576d68f-c5e2-416c-afb3-f97ba2279a39"),
                            Category = 8,
                            Description = "Agua carbonatada, azúcar, colorante, aromas (contiene cafeína), acidulante y edulcorantes. No contiene alérgenos de obligada declaración. Mejor que bueno.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53718859141_4f7509983e_c.jpg",
                            Name = "Gaseosa Pepsi Botella 2lt",
                            Price = 2.4m
                        },
                        new
                        {
                            ProductId = new Guid("becf9594-6ffd-4c20-a8f3-31e04ee80567"),
                            Category = 8,
                            Description = "Paquete en versión de 500g, Porotos alubias, puede contener soja",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719068053_43f1ef3725_c.jpg",
                            Name = "Porotos Mister Food Alubia",
                            Price = 550m
                        },
                        new
                        {
                            ProductId = new Guid("183e8b74-4957-4830-ad40-eeef482ace72"),
                            Category = 8,
                            Description = "Quínoa, zanahoria deshidratada, cebolla deshidratada, morrón deshidratado, espinaca deshidratada, perejil deshidratado, sal, azúcar, pimentón dulce, nuez moscada, coriandro, pimienta blanca.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719197404_d08d446ac1_c.jpg",
                            Name = "Quinoa Con Vegetales Y Champignones",
                            Price = 5.85m
                        },
                        new
                        {
                            ProductId = new Guid("2ca02f62-a772-4c33-b8ac-73e945073dad"),
                            Category = 9,
                            Description = "Editorial: Oberon, páginas: 336, idioma Español. Clasificación Ingenieria, Tecnica Y Ciencias Exactas - Otras Ciencias Exactas - Astronomia",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719027845_afa4363a12_c.jpg",
                            Name = "Vida En Marte - David A. Weintraub",
                            Price = 23.56m
                        },
                        new
                        {
                            ProductId = new Guid("10165778-d7b8-4313-82bc-14f9d5147177"),
                            Category = 9,
                            Description = "Editorial: RBA Bolsillo, páginas: 160, idioma Español. Clasificación Ingenieria, Tecnica Y Ciencias Exactas - Ingenieria - General",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53718804433_acc579be06_b.jpg",
                            Name = "Inteligencia Artificial (bolsillo) - Ignasi Belda Reig",
                            Price = 15.9m
                        },
                        new
                        {
                            ProductId = new Guid("0fee358b-68e2-48eb-bbf6-31b3db8f9cc2"),
                            Category = 9,
                            Description = "Que son las contraseñas? ?Como se construyen? ?En que momento de la historia surgieron? Estas son solo algunas de las preguntas que sirven como disparador para que Martin Paul Eve despliegue su conocimiento sobre las implicancias y el funcionamiento de las contraseñas",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53718804428_46d29bccb5_z.jpg",
                            Name = "Una Historia De Las Contr45eñ4s - Martin Paul Eve ",
                            Price = 17.999m
                        },
                        new
                        {
                            ProductId = new Guid("237c73b3-7ccb-4406-9374-d6b8155c96ea"),
                            Category = 9,
                            Description = "Explora la evolución de los videojuegos desde sus orígenes en el MIT hasta su posición actual como fenómeno mundial. Analiza la influencia de los arcades en la popularización del medio, el legado de Mario y su impacto en la cultura pop, y el éxito de Pokémon como estrategia de mercadeo basada en la nostalgia.",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53718804473_3470e0fddc_z.jpg",
                            Name = "FENOMENOS GAMERS, de Nicolas Rabago",
                            Price = 19.6m
                        },
                        new
                        {
                            ProductId = new Guid("c72b3166-d21f-4dad-84e5-b5a56cd387af"),
                            Category = 10,
                            Description = "La cortadora de cesped eléctrica DAC1600 de Daewoo cuenta con una potencia de 1600 watts , mientras que, el voltaje es de 220/50 Hz. A su vez posee una manija ergonómica para una mayor comodidad del usuario, es plegable y pertenece a la línea ECO. ",
                            Discount = 42,
                            ImageUrl = "https://live.staticflickr.com/65535/53717952837_e7c9735857_b.jpg",
                            Name = "Cortadora de césped Daewoo Eléctrica ",
                            Price = 349.999m
                        },
                        new
                        {
                            ProductId = new Guid("f9641bf4-eb19-4577-b81c-474212dff321"),
                            Category = 10,
                            Description = " La bordeadora de césped severbon cuenta con motor eléctrico y una potencia de 1000 watts. Posee una manija ajustable en altura, que te brindará una mayor comodidad y te facilitará su uso.",
                            Discount = 40,
                            ImageUrl = "https://live.staticflickr.com/65535/53718858996_1826022f50_b.jpg",
                            Name = "Bordeadora Eléctrica Severbon",
                            Price = 99.999m
                        },
                        new
                        {
                            ProductId = new Guid("1a82f1af-968f-4d70-a297-e48350acb98c"),
                            Category = 10,
                            Description = "Con su potencia de 105 bar podés dejar reluciente cualquier material o superficie. Su impacto de agua a alta presión es entre diez y cincuenta veces más potente que las mangueras de jardín, lo que hace más eficaz y fácil el proceso de limpieza.",
                            Discount = 33,
                            ImageUrl = "https://live.staticflickr.com/65535/53719197264_aba2f039b4_c.jpg",
                            Name = "Hidrolavadora Daewoo 1200 Watts 105 Bar con Autostop",
                            Price = 149.999m
                        },
                        new
                        {
                            ProductId = new Guid("53ae9c8f-2d09-493f-a063-faec17552338"),
                            Category = 10,
                            Description = "Con la Motosierra Philco podés hacer cortes profesionales de todo tipo de maderas, para podar, cortar árboles y hacer numerosos trabajos de jardinería. Es tu aliada perfecta para superar cualquier obstáculo. Con su diseño ergonómico y potente motor, te brinda la confianza y el control necesarios para realizar trabajos eficientes y precisos",
                            Discount = 0,
                            ImageUrl = "https://live.staticflickr.com/65535/53719067988_7233dcb4d5_c.jpg",
                            Name = "Motosierra Philco A Nafta Espada 45 Cm 52cc ",
                            Price = 199.999m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleId");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SaleProduct", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartId"));

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("Product")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Sale")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("Product");

                    b.HasIndex("Sale");

                    b.ToTable("SaleProduct", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Caregory", "Categoria")
                        .WithMany("Products")
                        .HasForeignKey("Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Domain.Entities.SaleProduct", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Producto")
                        .WithMany("SaleProducts")
                        .HasForeignKey("Product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Sale", "Venta")
                        .WithMany("SaleProducts")
                        .HasForeignKey("Sale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Domain.Entities.Caregory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("SaleProducts");
                });

            modelBuilder.Entity("Domain.Entities.Sale", b =>
                {
                    b.Navigation("SaleProducts");
                });
#pragma warning restore 612, 618
        }
    }
}