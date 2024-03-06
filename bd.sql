toc.dat                                                                                             0000600 0004000 0002000 00000005400 14572017674 0014453 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP           0                |            carrito_compras    14.3    14.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         �           1262    16419    carrito_compras    DATABASE     s   CREATE DATABASE carrito_compras WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
    DROP DATABASE carrito_compras;
                postgres    false         �            1259    16421    Products    TABLE     �   CREATE TABLE public."Products" (
    id integer NOT NULL,
    sku character varying(20) NOT NULL,
    name character varying(50),
    description character varying(200),
    "availableUnits" integer,
    "unitPrice" real
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
       public          postgres    false    209    210    210         �          0    16421    Products 
   TABLE DATA           _   COPY public."Products" (id, sku, name, description, "availableUnits", "unitPrice") FROM stdin;
    public          postgres    false    210       3307.dat �           0    0    Product_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Product_id_seq"', 2, true);
          public          postgres    false    209         ^           2606    16426    Products Product_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Product_pkey" PRIMARY KEY (id);
 C   ALTER TABLE ONLY public."Products" DROP CONSTRAINT "Product_pkey";
       public            postgres    false    210                                                                                                                                                                                                                                                                        3307.dat                                                                                            0000600 0004000 0002000 00000000117 14572017674 0014262 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        1	EA_01	hablame	soy un chorizo	2	2.3
2	EA_02	hablame	soy un chorizo	2	2.3
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                 restore.sql                                                                                         0000600 0004000 0002000 00000005603 14572017674 0015405 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
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
    name character varying(50),
    description character varying(200),
    "availableUnits" integer,
    "unitPrice" real
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

COPY public."Products" (id, sku, name, description, "availableUnits", "unitPrice") FROM stdin;
\.
COPY public."Products" (id, sku, name, description, "availableUnits", "unitPrice") FROM '$$PATH$$/3307.dat';

--
-- Name: Product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Product_id_seq"', 2, true);


--
-- Name: Products Product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "Product_pkey" PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             