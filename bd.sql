toc.dat                                                                                             0000600 0004000 0002000 00000005506 14572635014 0014454 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP                           |            carrito_compras    14.3    14.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         �           1262    16419    carrito_compras    DATABASE     s   CREATE DATABASE carrito_compras WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
    DROP DATABASE carrito_compras;
                postgres    false         �            1259    16421    Products    TABLE       CREATE TABLE public."Products" (
    id integer NOT NULL,
    sku character varying(20) NOT NULL,
    name character varying(50) NOT NULL,
    description character varying(200),
    "availableUnits" integer NOT NULL,
    "unitPrice" real NOT NULL,
    image character varying(255)
);
    DROP TABLE public."Products";
       public         heap    postgres    false         �            1259    16420    Product_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Product_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."Product_id_seq";
       public          postgres    false    210         �           0    0    Product_id_seq    SEQUENCE OWNED BY     F   ALTER SEQUENCE public."Product_id_seq" OWNED BY public."Products".id;
          public          postgres    false    209         \           2604    16424    Products id    DEFAULT     m   ALTER TABLE ONLY public."Products" ALTER COLUMN id SET DEFAULT nextval('public."Product_id_seq"'::regclass);
 <   ALTER TABLE public."Products" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    210    209    210         �          0    16421    Products 
   TABLE DATA           f   COPY public."Products" (id, sku, name, description, "availableUnits", "unitPrice", image) FROM stdin;
    public          postgres    false    210       3307.dat �           0    0    Product_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Product_id_seq"', 142, true);
          public          postgres    false    209         ^           2606    16426    Products Product_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Product_pkey" PRIMARY KEY (id);
 C   ALTER TABLE ONLY public."Products" DROP CONSTRAINT "Product_pkey";
       public            postgres    false    210                                                                                                                                                                                                  3307.dat                                                                                            0000600 0004000 0002000 00000010756 14572635014 0014266 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        73	EA_1	NORMAL_PRODUCT_1	\N	50	1000	./images/EA/download (1).jpg
74	EA_2	NORMAL_PRODUCT_2	\N	50	1200	./images/EA/download (10).jpg
75	EA_3	NORMAL_PRODUCT_3	\N	50	1250	./images/EA/download (11).jpg
76	EA_4	NORMAL_PRODUCT_4	\N	50	1250	./images/EA/download (12).jpg
77	EA_5	NORMAL_PRODUCT_5	\N	50	320	./images/EA/download (2).jpg
78	EA_6	NORMAL_PRODUCT_6	\N	50	233	./images/EA/download (3).jpg
79	EA_7	NORMAL_PRODUCT_7	\N	50	2458	./images/EA/download (4).jpg
80	EA_8	NORMAL_PRODUCT_8	\N	50	256	./images/EA/download (5).jpg
81	EA_9	NORMAL_PRODUCT_9	\N	50	4872	./images/EA/download (6).jpg
82	EA_10	NORMAL_PRODUCT_10	\N	50	251	./images/EA/download (7).jpg
83	EA_11	NORMAL_PRODUCT_11	\N	50	2230	./images/EA/download (8).jpg
84	EA_12	NORMAL_PRODUCT_12	\N	50	150	./images/EA/download (9).jpg
85	EA_13	NORMAL_PRODUCT_13	\N	50	1658	./images/EA/download.jpg
86	EA_14	NORMAL_PRODUCT_14	\N	50	1554	./images/EA/images (1).jpg
87	EA_15	NORMAL_PRODUCT_15	\N	50	1000	./images/EA/images (10).jpg
88	EA_16	NORMAL_PRODUCT_16	\N	50	1200	./images/EA/images (11).jpg
89	EA_17	NORMAL_PRODUCT_17	\N	50	1250	./images/EA/images (12).jpg
90	EA_18	NORMAL_PRODUCT_18	\N	50	1250	./images/EA/images (13).jpg
91	EA_19	NORMAL_PRODUCT_19	\N	50	320	./images/EA/images (14).jpg
92	EA_20	NORMAL_PRODUCT_20	\N	50	233	./images/EA/images (15).jpg
93	EA_21	NORMAL_PRODUCT_21	\N	50	2458	./images/EA/images (16).jpg
94	EA_22	NORMAL_PRODUCT_22	\N	50	256	./images/EA/images (17).jpg
95	EA_23	NORMAL_PRODUCT_23	\N	50	4872	./images/EA/images (2).jpg
96	EA_24	NORMAL_PRODUCT_24	\N	50	251	./images/EA/images (3).jpg
97	EA_25	NORMAL_PRODUCT_25	\N	50	2230	./images/EA/images (4).jpg
98	EA_26	NORMAL_PRODUCT_26	\N	50	150	./images/EA/images (5).jpg
99	EA_27	NORMAL_PRODUCT_27	\N	50	1658	./images/EA/images (6).jpg
100	EA_28	NORMAL_PRODUCT_28	\N	50	1554	./images/EA/images (7).jpg
101	EA_29	NORMAL_PRODUCT_29	\N	50	154	./images/EA/images (8).jpg
102	EA_30	NORMAL_PRODUCT_30	\N	50	780	./images/EA/images (9).jpg
103	WE_1	WEIGHT_PRODUCT_1	\N	200	15	./images/WE/download (1).jpg
104	WE_2	WEIGHT_PRODUCT_2	\N	200	15	./images/WE/download (2).jpg
105	WE_3	WEIGHT_PRODUCT_3	\N	200	20	./images/WE/download (3).jpg
106	WE_4	WEIGHT_PRODUCT_4	\N	200	26	./images/WE/download (4).jpg
107	WE_5	WEIGHT_PRODUCT_5	\N	200	20	./images/WE/download (5).jpg
108	WE_6	WEIGHT_PRODUCT_6	\N	200	23	./images/WE/download (6).jpg
109	WE_7	WEIGHT_PRODUCT_7	\N	200	25	./images/WE/download (7).jpg
110	WE_8	WEIGHT_PRODUCT_8	\N	200	52	./images/WE/download (8).jpg
111	WE_9	WEIGHT_PRODUCT_9	\N	200	48	./images/WE/download.jpg
112	WE_10	WEIGHT_PRODUCT_10	\N	200	15	./images/WE/images (1).jpg
113	WE_11	WEIGHT_PRODUCT_11	\N	200	15	./images/WE/images (10).jpg
114	WE_12	WEIGHT_PRODUCT_12	\N	200	20	./images/WE/images (2).jpg
115	WE_13	WEIGHT_PRODUCT_13	\N	200	26	./images/WE/images (3).jpg
116	WE_14	WEIGHT_PRODUCT_14	\N	200	20	./images/WE/images (4).jpg
117	WE_15	WEIGHT_PRODUCT_15	\N	200	23	./images/WE/images (5).jpg
118	WE_16	WEIGHT_PRODUCT_16	\N	200	25	./images/WE/images (6).jpg
119	WE_17	WEIGHT_PRODUCT_17	\N	200	52	./images/WE/images (7).jpg
120	WE_18	WEIGHT_PRODUCT_18	\N	200	48	./images/WE/images (8).jpg
121	WE_19	WEIGHT_PRODUCT_19	\N	200	89	./images/WE/images (9).jpg
122	WE_20	WEIGHT_PRODUCT_20	\N	200	96	./images/WE/images.jpg
123	SP_1	SPECIAL_PRODUCT_1	\N	10	10000	./images/SP/images (1).jpg
124	SP_2	SPECIAL_PRODUCT_2	\N	10	15000	./images/SP/images (10).jpg
125	SP_3	SPECIAL_PRODUCT_3	\N	10	15000	./images/SP/images (11).jpg
126	SP_4	SPECIAL_PRODUCT_4	\N	10	2600	./images/SP/images (12).jpg
127	SP_5	SPECIAL_PRODUCT_5	\N	10	2300	./images/SP/images (13).jpg
128	SP_6	SPECIAL_PRODUCT_6	\N	10	5894	./images/SP/images (14).jpg
129	SP_7	SPECIAL_PRODUCT_7	\N	10	4500	./images/SP/images (15).jpg
130	SP_8	SPECIAL_PRODUCT_8	\N	10	2630	./images/SP/images (16).jpg
131	SP_9	SPECIAL_PRODUCT_9	\N	10	2590	./images/SP/images (17).jpg
132	SP_10	SPECIAL_PRODUCT_10	\N	10	10000	./images/SP/images (18).jpg
133	SP_11	SPECIAL_PRODUCT_11	\N	10	15000	./images/SP/images (19).jpg
134	SP_12	SPECIAL_PRODUCT_12	\N	10	15000	./images/SP/images (2).jpg
135	SP_13	SPECIAL_PRODUCT_13	\N	10	2600	./images/SP/images (3).jpg
136	SP_14	SPECIAL_PRODUCT_14	\N	10	2300	./images/SP/images (4).jpg
137	SP_15	SPECIAL_PRODUCT_15	\N	10	5894	./images/SP/images (5).jpg
138	SP_16	SPECIAL_PRODUCT_16	\N	10	4500	./images/SP/images (6).jpg
139	SP_17	SPECIAL_PRODUCT_17	\N	10	2630	./images/SP/images (7).jpg
140	SP_18	SPECIAL_PRODUCT_18	\N	10	2590	./images/SP/images (8).jpg
141	SP_19	SPECIAL_PRODUCT_19	\N	10	10000	./images/SP/images (9).jpg
142	SP_20	SPECIAL_PRODUCT_20	\N	10	15000	./images/SP/images.jpg
\.


                  restore.sql                                                                                         0000600 0004000 0002000 00000005720 14572635014 0015377 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 14.3
-- Dumped by pg_dump version 14.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE carrito_compras;
--
-- Name: carrito_compras; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE carrito_compras WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';


ALTER DATABASE carrito_compras OWNER TO postgres;

\connect carrito_compras

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Products" (
    id integer NOT NULL,
    sku character varying(20) NOT NULL,
    name character varying(50) NOT NULL,
    description character varying(200),
    "availableUnits" integer NOT NULL,
    "unitPrice" real NOT NULL,
    image character varying(255)
);


ALTER TABLE public."Products" OWNER TO postgres;

--
-- Name: Product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Product_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Product_id_seq" OWNER TO postgres;

--
-- Name: Product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Product_id_seq" OWNED BY public."Products".id;


--
-- Name: Products id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products" ALTER COLUMN id SET DEFAULT nextval('public."Product_id_seq"'::regclass);


--
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Products" (id, sku, name, description, "availableUnits", "unitPrice", image) FROM stdin;
\.
COPY public."Products" (id, sku, name, description, "availableUnits", "unitPrice", image) FROM '$$PATH$$/3307.dat';

--
-- Name: Product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Product_id_seq"', 142, true);


--
-- Name: Products Product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Product_pkey" PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                