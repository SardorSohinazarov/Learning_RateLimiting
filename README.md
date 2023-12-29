# `Rate limiting` haqida hammasi.

### `Rate limiting` - dasturlarga qabul qilinuvchi so'rovlar sonini normallashtirish vositasi.

> #### Bir nechta Rate limiter algorithm turlari:
> - **Fixed window**
> - **Sliding window**
> - **Token bucket**
> - **Concurrency**

> - **1. Fixed window**
```
//service
builder.Services.AddRateLimiter(x =>
{
    x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    x.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(60);
        options.PermitLimit = 60;
        options.QueueLimit = 20;
    });
});

//middleware
app.UseRateLimiter();

//action attribute
[EnableRateLimiting("fixed")]
```

Mustaqil o'rganib olish uchun [tavsiya qilaman(o'zbekcha)](https://www.youtube.com/watch?v=phpZFkufcHo).
