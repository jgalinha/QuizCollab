namespace QuizCollab.Domain.Permissions;

public interface IPesmissionsRepository
{
    Task<Permission> GetPermissionById(Guid permissionId, CancellationToken cancellationToken = default);

    void AddPermission(Permission permission);
}