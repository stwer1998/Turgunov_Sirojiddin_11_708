--"1. Получить имена поставщиков, которые поставляют деталь Д2"
SELECT p.PFAM FROM PSTS p
WHERE p.PNOM IN (SELECT PNOM FROM PST WHERE DNOM='Д2')

--"2. Получить имена поставщиков, которые поставляют по меньшей мере одну красную деталь"
SELECT PFAM FROM PSTS
WHERE PNOM IN
(SELECT PNOM FROM PST WHERE KOL>1 AND DNOM IN
(SELECT D.DNOM FROM DET D WHERE D.COLOR='КРАСНЫЙ'))

--"3. Получить имена тяжелых (вес>14) деталей, которые поставляются поставщиками из МОСКВЫ"
SELECT D.DNAME FROM DET D
WHERE D.VES>12 AND D.DNOM IN
(SELECT DNOM FROM PST WHERE PNOM IN
(SELECT PNOM FROM PSTS WHERE CITY='МОСКВА'))


--"4. Получить номера поставщиков из Москвы со статусом больше 20"
SELECT PNOM FROM PSTS WHERE STATUS >20 AND CITY='МОСКВА'

--"5. Получить имена поставщиков, которые поставляют все детали"
SELECT DISTINCT ps.PFAM FROM PSTS ps
WHERE NOT EXISTS
(SELECT * FROM DET d
WHERE NOT EXISTS(SELECT * FROM PST p
WHERE p.PNOM=ps.PNOM AND p.DNOM=d.DNOM)) 

--"6. Получить номера поставщиков, поставляющих по крайней мере
-- все те детали, которые поставляет поставщик СИДОРОВ"
SELECT ps.PFAM FROM PSTS ps
WHERE NOT EXISTS (SELECT * FROM DET d
WHERE NOT EXISTS(SELECT * FROM PST p
WHERE p.PNOM='П4'AND p.DNOM=d.DNOM))



--"0.1 реляционная алгебра"
--"0.2 реляционное исчисление"
--"1.1"
SELECT ps.PFAM FROM PSTS ps
 JOIN PST p ON p.DNOM='Д2'AND p.PNOM=ps.PNOM
 --"1.2"
 SELECT ps.PFAM FROM PSTS ps
 WHERE EXISTS (SELECT * FROM PST AS p WHERE p.DNOM='Д2'AND ps.PNOM=p.PNOM) 

--"2.1"
SELECT DISTINCT ps.PFAM FROM PSTS ps
JOIN PST p ON p.PNOM=ps.PNOM
JOIN DET d ON p.DNOM=d.DNOM AND d.COLOR='КРАСНЫЙ'

--"2.2"
SELECT ps.PFAM FROM PSTS ps
WHERE EXISTS (SELECT * FROM PST p WHERE p.PNOM=ps.PNOM AND EXISTS(SELECT * FROM DET d
WHERE d.COLOR='КРАСНЫЙ'AND d.DNOM=p.DNOM))

--"3.1"
SELECT DISTINCT d.DNAME FROM DET d
JOIN PST p ON p.DNOM=d.DNOM
JOIN PSTS ps ON ps.PNOM=p.PNOM AND ps.CITY='МОСКВА'
WHERE d.VES>14

--"3.2"
SELECT d.DNAME FROM DET d
WHERE d.VES>14 AND EXISTS (SELECT * FROM PST p WHERE p.DNOM=d.DNOM AND 
EXISTS (SELECT * FROM PSTS ps WHERE ps.PNOM=p.PNOM AND ps.CITY='МОСКВА'))

--"4"
SELECT ps.PNOM FROM PSTS ps
WHERE ps.STATUS>20 AND ps.CITY='МОСКВА'

--"5.1.2"
SELECT ps.PFAM FROM PSTS ps
WHERE NOT EXISTS (SELECT * FROM DET d
WHERE NOT EXISTS (SELECT * FROM PST p 
WHERE p.PNOM=ps.PNOM AND d.DNOM=p.DNOM))

--"0.1.1"
SELECT * FROM DET d
JOIN PST p ON d.DNOM=p.DNOM AND p.KOL>200
JOIN PSTS ps ON ps.PNOM=p.PNOM AND ps.CITY='МОСКВА'

--"0.1.2"
SELECT * FROM DET d
WHERE EXISTS(SELECT * FROM PSTS ps
WHERE EXISTS(SELECT * FROM PST p 
WHERE p.KOL>200 AND p.DNOM=d.DNOM AND p.PNOM=ps.PNOM AND ps.CITY='МОСКВА'))

--"13.1"
SELECT * FROM DET d
JOIN PST p ON p.DNOM=d.DNOM
JOIN PSTS ps ON p.PNOM<>ps.PNOM AND ps.CITY!='Казань
' 