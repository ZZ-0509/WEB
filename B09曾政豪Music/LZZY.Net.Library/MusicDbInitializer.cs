using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace LZZY.Net.Library
{
    public class MusicDbInitializer : DropCreateDatabaseIfModelChanges<MusicDbContext>
    {
        /// <summary>
        /// 编写种子文件
        /// </summary>
        /// <param name="DbContext"></param>
        protected override void Seed(MusicDbContext DbContext)
        {
            var role = new List<Role>()
            {
                new Role() {RoleName="普通用户",Resume="一般用户权限" },
                new Role() {RoleName="管理员",Resume="普通管理员权限" },
                new Role() {RoleName="超级管理员",Resume="超级管理员权限" }
            };
            new List<User>()
            {
                new User() {Email="2018@mdc",Password="123456",UserName="张三",Regtime=Convert.ToDateTime("2017-11-16"),Role=role.Single(b=>b.RoleName=="普通用户") },
                new User() {Email="2017@mdc",Password="13456",UserName="李四",Regtime=Convert.ToDateTime("2017-02-16"),Role=role.Single(b=>b.RoleName=="管理员") },
                new User() {Email="2020@mdc",Password="224466",UserName="武久",Regtime=Convert.ToDateTime("2018-11-16"), Role=role.Single(b=>b.RoleName=="超级管理员")},
                new User() {Email="2019@mdc",Password="13468",UserName="王二",Regtime=Convert.ToDateTime("2019-09-16"),Role=role.Single(b=>b.RoleName=="普通用户") },
            }.ForEach(a => DbContext.Users.Add(a));


            var genre = new List<Genre>()
            {
                 new Genre() {GenreName="乡村音乐",Describe="起源于美国西海岸，歌唱时只 有吉他伴奏，曲调抒情。" },
                 new Genre() {GenreName="迪斯科乐 ",Describe="在摇摆舞音乐中加上强烈的节奏鼓。" },
                 new Genre() {GenreName="爵士摇摆乐",Describe="传统的爵士乐加上较和谐 的配器。" },
                 new Genre() {GenreName="滚石乐",Describe="音乐节奏感强" },
                 new Genre() {GenreName="颓废派摇滚乐",Describe="曲调怪诞做作，20世纪70 年代初风行一时。" },
                 new Genre() {GenreName="进步音乐",Describe="带有摇滚乐的色彩，音响效果较好。" },
                 new Genre() {GenreName="通俗流行音乐",Describe="集各流派之大成，曲调朴实。" },
                 new Genre() {GenreName="莱卡音乐",Describe="受牙买加民族音乐节奏影响而 形成的一种音乐。" },
                 new Genre() {GenreName="歌妓音乐",Describe="唱对发音不加任何修饰，有 时近乎于喊。" },
                 new Genre() {GenreName="黑人音乐",Describe="取材于黑人歌曲，节奏感较强。" }
            };
            var singer = new List<Singer>()
            {
                new Singer() {SingerName="曾骁",Gender="男",Introduce="dsafasd" },
                new Singer() {SingerName="肖博约",Gender="男",Introduce="gfbfsgb" },
                new Singer() {SingerName="董细薇",Gender="女",Introduce="ewrqwefddv" },
                new Singer() {SingerName="高倩玉",Gender="女",Introduce="erqfrg" },
                new Singer() {SingerName="伊婷",Gender="女",Introduce="cxcvfda" },
                new Singer() {SingerName="邓宸",Gender="男",Introduce="fghjgfd" },
                new Singer() {SingerName="张晓",Gender="男",Introduce="dfijdiew" },
                new Singer() {SingerName="冉利娜",Gender="女",Introduce="nbbnfhgr" },
                new Singer() {SingerName="邱雨",Gender="女",Introduce="asdsgege" },
                new Singer() {SingerName="张云雷",Gender="男",Introduce="jyujnnrgr" },

            };
            new List<Album>()
            {
                new Album() {AlbumName="过海",Price=18,ShelfTime=Convert.ToDateTime("2019-12-16"),Genre=genre.Single(b=>b.GenreName=="乡村音乐"),Singer=singer.Single(b=>b.SingerName=="董细薇"),Website="/Content/filepath/placeholder.gif" },
                new Album() {AlbumName="蓝色天空",Price=6,ShelfTime=Convert.ToDateTime("2019-10-18"),Genre=genre.Single(b=>b.GenreName=="爵士摇摆乐"),Singer=singer.Single(b=>b.SingerName=="邱雨"),Website="/Content/filepath/placeholder.gif" },
                new Album() {AlbumName="《灵笼》第一季原声大碟",Price=20,ShelfTime=Convert.ToDateTime("2017-08-16"),Genre=genre.Single(b=>b.GenreName=="乡村音乐"),Singer=singer.Single(b=>b.SingerName=="高倩玉"),Website="/Content/filepath/placeholder.gif" },
                new Album() {AlbumName="敦煌定若远",Price=15,ShelfTime=Convert.ToDateTime("2018-08-31"),Genre=genre.Single(b=>b.GenreName=="颓废派摇滚乐"),Singer=singer.Single(b=>b.SingerName=="冉利娜"),Website="/Content/filepath/placeholder.gif" },
                new Album() {AlbumName="就要掷地有声的炸裂",Price=12,ShelfTime=Convert.ToDateTime("2019-08-06"),Genre=genre.Single(b=>b.GenreName=="黑人音乐"),Singer=singer.Single(b=>b.SingerName=="伊婷"),Website="/Content/filepath/placeholder.gif" },
                new Album() {AlbumName="LUNAR",Price=14,ShelfTime=Convert.ToDateTime("2019-07-11"),Genre=genre.Single(b=>b.GenreName=="爵士摇摆乐"),Singer=singer.Single(b=>b.SingerName=="张云雷"),Website="/Content/filepath/placeholder.gif" },
                new Album() {AlbumName="True Colors",Price=10,ShelfTime=Convert.ToDateTime("2018-09-21"),Genre=genre.Single(b=>b.GenreName=="莱卡音乐"),Singer=singer.Single(b=>b.SingerName=="曾骁"),Website="/Content/filepath/placeholder.gif" },


           }.ForEach(a => DbContext.Albums.Add(a));


        }

    }
}
