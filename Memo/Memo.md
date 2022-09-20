# 備忘録的なメモ
LaserとReticleを無効化にするとハンドだけを表示できる。

[![Image from Gyazo](https://i.gyazo.com/f05020099c0533a932d8ca007ea1b49c.png)](https://gyazo.com/f05020099c0533a932d8ca007ea1b49c)

ハンドとアバターとの接触判定は`HandTrackingExample/GrabbleItems/Grabbers/NRGrabber_Right/Sphere`で行っている。つまり、このSphereのcollisionとアバターにつけたcollisionで接触判定が起きる。

この`Sphere`はデフォルトで`Is Trigger`がオンになっているので、Collisionを使って接触判定をする場合は`Is Trigger`をオフにする必要あり。

<img width="920" alt="スクリーンショット 2022-09-19 16 07 56" src="https://user-images.githubusercontent.com/69253001/190966722-2b46e926-1a4c-4139-92d3-46558f0a43c5.png">

---

こういうふうに、接触判定はさせるけど、物体を動かしたくない場合は`Is Kinematic`をオンにする。
![isKinematicSample](https://user-images.githubusercontent.com/69253001/190969968-0c9f0d58-0949-4151-828f-3acee36fd8e8.gif)

- [参考元](https://bardaxel.jp/archives/15)

今回の場合は、`Sphere`と`Cube`にRigitBodyをつけて、`Cube`だけ、`Is Kinematic`をオンにした。

<img width="1243" alt="スクリーンショット 2022-09-19 16 38 06" src="https://user-images.githubusercontent.com/69253001/190970775-a28cbf5c-e8cb-443b-a8bd-d153a13a8b63.png">
<img width="1244" alt="スクリーンショット 2022-09-19 16 38 38" src="https://user-images.githubusercontent.com/69253001/190970796-0ca9a96f-2c26-4a4f-82d5-991cccc6746a.png">

---

```cs
foreach (ContactPoint point in collision.contacts)
        {
            Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(
                null,
                point.point
                );
        }
```

ここの`point.point`はVector3であり、`Sphere`と`Cube`が接触した座標を表している。
- [参考元](https://kasatanet.hatenablog.com/entry/2017/06/05/191540)

`RectTransformUtility.WorldToScreenPoint`で接触した座標（ワールド座標）をもとに、Textを表示するスクリーン座標を計算している。
- [参考元](https://light11.hatenadiary.com/entry/2019/04/16/003642#:~:text=%E3%81%93%E3%81%AE%E3%82%88%E3%81%86%E3%81%AB%E3%81%AA%E3%82%8A%E3%81%BE%E3%81%99%E3%80%82-,%E3%83%AF%E3%83%BC%E3%83%AB%E3%83%89%E5%BA%A7%E6%A8%99%E3%82%92%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%BC%E3%83%B3%E5%BA%A7%E6%A8%99%E3%81%AB%E5%A4%89%E6%8F%9B,-%E3%83%AF%E3%83%BC%E3%83%AB%E3%83%89%E5%BA%A7%E6%A8%99%E3%82%92)

また、最初に`Cube`に接触する際に、勢いよく`Sphere`を`Cube`に触ると、その後の接触判定が`Cube`の内側になってしまうので、最初に`Cube`に接触する際はゆっくり触る必要あり。
- つまり、最初の接触判定によってその後の接触判定も変わってくるので、最初はゆっくり触った方がいい。

---

ハンドトラッキングで手が動いている座標は非常に小さな値なので、`Sphere`と`Cube`の接触点である`point.point`も小さな値になり、screenPosも小さな値になる。なので、スケールアップする必要がある。
