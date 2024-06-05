/***************** To-Do ****************
 * 
 * *********** Güncellenecekler ***********
 * 
 * Hotbar sistemi TakeOnHand metodu kullanılacak şekilde güncelenmesi gerekiyor.
 * Tool etkileşimleri raycast ile yapılması gerek.
 * Mesh collider kullanımı azaltılması gerekiyor.
 * Lod sistemi ve Occulusion revize edilecek.
 * Toplama ve atma işlevleri destroy yerine havuzlama yöntemine çevrilebilir.
 * Post-process güncellenecek.
 * Bazı Modeller ve karakter elden geçirilmeli.
 * Minimap a çerçeve eklenecek.
 * 
 * *********** Hatalar ***********
 * 
 * Oyuncu elindeki objeyide collect ediyor. (Taglar kullanılmalı)
 * Plane Terraine çevrilemedeiği için 2d çimen kullanılamıyor.
 * Çanta dolunca objeler alınamıyor fakat alınmış gibi siliniyor.
 * Free modda yerden birşey toplanamıyor.
 * Axe ın verdiği damageyi scriptable objeden alması gerekiyor.
 * İstifleme çalışmıyor.
 * Oyuncunun elindeki nesne envanterden atıldığında oyuncunun elinden silinmiyor.
 * ItemSO enum sistemi yetersiz kalıyor item tipleri için ItemSO enumlarının özelleştirilmesi gerekiyor.+
 * Hotbarda boş olan bir slot seçildiğinde eldeki mevcu objenin kapatılması gerekir.+
 * Eldeki kullanılabilir nesnelere tipine göre animasyon eklenmesi ve hareket ederken de uygun bir şekilde çalışması gerekir.
 * Action mode için hareketlerin yumuşatılması gerekir.
 * Animasyonlar için kafa hareketleri ve dönüş animasyonu eklenmesi gerekir.
 * Occlusion colliderları kapatmıyor.
 * Tool objelerinin tümü ağaç kesebilir. Enumların düzeltilmesi gerekiyor dict e geçilebilir.
 * Bazı objeler plane den geçerek aşağıya düşüyor, stickler envanterden atıldıktan sonra planenin içinden geçiyor. +
 * Tab Menüdeyken camera hareketini durdurulması gerekir. +
 * Kamera plane nin ve suyun içine girmemesi gerekir.
 * 
 * *********** Eklenecekler ***********
 * 
 * Meşale ve ateş efekti eksik
 * Ana menü ve pause menü
 * Yeni craft nesneleri
 * İnşa sistemi (Basit Barınak,Yaprak ve otların eklenmesi) (Sonrasında Soket sistemi)
 * Yeni inşa nesneleri (Ev,Çadır ...)
 * Can, yemek ve su sisteminin eklenmesi
 * Toplayıcılık(Meyveler ve mantar)
 * Avcılık (Hayvanların eklenmesi)
 * Balıkçılık
 * Tarım
 * Gece gündüz döngüsü ve değişken hava durumu eklenmesi
 * Dere ve göl için shader eklenmesi (oyuncu y ekseninde belli bir seviyenin altına inemez ve yüzme animasyonu devreye girer)
 * 
 * *********** Oyuna Item Ekleme ***********
 * 
 * Bir item eklenirken ItemSo klasörüne scriptable obje oluşturulması ve gerekli ayarların yapılması gerekir.
 * Yeni eklenecek kullanılabilir itemlerin oyuncunun eline ve oyuncunun elindeki itemlerin de holdableObjects listesine eklenmesi gerekir.
 * 
 */



