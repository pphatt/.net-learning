using ErrorOr;

namespace Server.Domain.Common.Errors;

public static partial class Errors
{
    public static class Post
    {
        public static Error AlreadyExist
            => Error.Validation(code: "Post.AlreadyExist", description: "Post already exist");

        public static Error NotFound
            => Error.NotFound(code: "Post.NotFound", description: "Post not found");

        public static Error Delete
            => Error.Validation(code: "Post.Delete", description: "Post already deleted");
    }
}
