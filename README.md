# `Rate limiting` haqida hammasi.

### `Rate limiting` - dasturlarga qabul qilinuvchi so'rovlar sonini normallashtirish vositasi.

> #### Bir nechta Rate limiter algorithm turlari:
> - **Fixed window**
> - **Sliding window**
> - **Token bucket**
> - **Concurrency**


> - **1. Fixed window**
> ```
> //service
> builder.Services.AddRateLimiter(x =>
> {
>     x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
> 
>     x.AddFixedWindowLimiter("fixed", options =>
>     {
>         options.Window = TimeSpan.FromSeconds(60);
>         options.PermitLimit = 60;
>         options.QueueLimit = 20;
>     });
> });
> 
> //middleware
> app.UseRateLimiter();
> 
> //action attribute
> [EnableRateLimiting("fixed")]
> ```


> - **2. Sliding window**
> ```
> //service
> builder.Services.AddRateLimiter(x =>
> {
>     x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
> 
>     x.AddSlidingWindowLimiter("sliding", options =>
>     {
>         options.Window = TimeSpan.FromSeconds(60);
>         options.SegmentsPerWindow = 6;
>         options.PermitLimit = 60;
>         options.QueueLimit = 10;
>   });
> });
> 
> //middleware
> app.UseRateLimiter();
> 
> //action attribute
> [EnableRateLimiting("sliding")]
> ```


> - **3. Token bucket**
> ```
> //service
> builder.Services.AddRateLimiter(x =>
> {
>     x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
> 
>     x.AddTokenBucketLimiter("bucket", options =>
>     {
>          options.ReplenishmentPeriod = TimeSpan.FromSeconds(60);
>          options.TokenLimit = 60;
>          options.TokensPerPeriod = 20;
>          options.AutoReplenishment = true;
>     });
> });
> 
> //middleware
> app.UseRateLimiter();
> 
> //action attribute
> [EnableRateLimiting("bucket")]
> ```

> - **4. Token bucket**
> ```
> //service
> builder.Services.AddRateLimiter(x =>
> {
>     x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
> 
>     x.AddConcurrencyLimiter("concurrency", options =>
>     {
>          options.PermitLimit = 2;
>     });
> });
> 
> //middleware
> app.UseRateLimiter();
> 
> //action attribute
> [EnableRateLimiting("concurrency")]
> ```

Keyinroq to'liq yozib qo'yaman.

Mustaqil o'rganib olish uchun [tavsiya qilaman(o'zbekcha)](https://www.youtube.com/watch?v=phpZFkufcHo).
