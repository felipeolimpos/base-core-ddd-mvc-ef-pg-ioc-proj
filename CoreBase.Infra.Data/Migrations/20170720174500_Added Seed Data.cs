using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBase.Infra.Data.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    INSERT INTO public.""PaymentMethods""(""Active"", ""CreatedAt"", ""Name"")
                    VALUES (true, CURRENT_DATE, 'Credit Card');
                    INSERT INTO public.""PaymentMethods""(""Active"", ""CreatedAt"", ""Name"")
                    VALUES (true, CURRENT_DATE, 'PayPal');
                    INSERT INTO public.""PaymentMethods""(""Active"", ""CreatedAt"", ""Name"")
                    VALUES (true, CURRENT_DATE, 'BitCoin');
                ");

            migrationBuilder.Sql(@"
                    INSERT INTO public.""Categories""(""Active"", ""CreatedAt"", ""Description"", ""Name"")
                    VALUES (true, CURRENT_DATE, 'A whole library for you!', 'Books');
                    INSERT INTO public.""Categories""(""Active"", ""CreatedAt"", ""Description"", ""Name"")
                    VALUES (true, CURRENT_DATE, 'The most advanced products!', 'Computers');
                    INSERT INTO public.""Categories""(""Active"", ""CreatedAt"", ""Description"", ""Name"")
                    VALUES (true, CURRENT_DATE, 'All about smartphones (iPhone, Android and Windows Phone).', 'Smartphones');
                    INSERT INTO public.""Categories""(""Active"", ""CreatedAt"", ""Description"", ""Name"")
                    VALUES (true, CURRENT_DATE, 'Everything you need to get some fun!', 'Sports');
                ");


            migrationBuilder.Sql(@"
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (1, true, CURRENT_DATE, 'Best book to learn software!', 'Cracking the Code Interview', 10);
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (1, true, CURRENT_DATE, 'Classic !', 'Lord of the Rings', 5);
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (1, true, CURRENT_DATE, 'Some say it was plagiarized from LOD, HP and some other...', 'Eragon', 15);
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (1, true, CURRENT_DATE, 'All laws you can think of put together!', 'Vade Mecum', 25);
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (2, true, CURRENT_DATE, 'Good enough computer', 'HP Pavillion', 1000);
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (2, true, CURRENT_DATE, 'Very good computer', 'Dell Inspiron', 1500);
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (3, true, CURRENT_DATE, 'Fair priced phone', 'Samsung Galaxy SX', 200);
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (3, true, CURRENT_DATE, 'Expensive phone', 'iPhone X', 5000);
                    INSERT INTO public.""Products""(""CategoryId"", ""Active"", ""CreatedAt"", ""Description"", ""Name"", ""Price"")
                    VALUES (4, true, CURRENT_DATE, 'Let''s play some ball ?!', 'Soccer Ball', 10);
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM public.""Categories""");
            migrationBuilder.Sql(@"DELETE FROM public.""Products""");
            migrationBuilder.Sql(@"DELETE FROM public.""PaymentMethods""");
        }
    }
}
